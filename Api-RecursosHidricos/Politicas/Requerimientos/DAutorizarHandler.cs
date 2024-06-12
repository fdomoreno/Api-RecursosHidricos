using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Api_RecursosHidricos.Politicas.Requerimientos
{
	public class DAutorizarHandler : AuthorizationHandler<DAutorizarPoliticaRequerimiento>
	{

        IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

        public DAutorizarHandler(IHttpContextAccessor httpContextAccessor)
		{
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DAutorizarPoliticaRequerimiento requirement)
        {
            bool autorizado = false;
            try
            {
                _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("clientId", out var clientId);
                _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

                if(String.IsNullOrEmpty(token) || String.IsNullOrEmpty(clientId))
                {
                    context.Fail();
                    return SetResponseAsync("No autorizado, no se envía Token y/o clientId", 401);
                }
                var aut = AuthenticationHeaderValue.Parse(token);
                if (aut.Scheme != "Bearer")
                {
                    context.Fail();
                    return SetResponseAsync("No autorizado, no se envía Token Bearer", 401);
                }
                //Verificar si el clientId es un claims en el token
                var claims = aut.Parameter.Split('.');
                var payload = claims[1];
                payload = payload.Replace('-', '+').Replace('_', '/');
                switch(payload.Length % 4)
                {
                    case 2: payload += "=="; break;
                    case 3: payload += "="; break;
                }
                var jsonPayload = Encoding.UTF8.GetString(Convert.FromBase64String(payload));
                var payloadData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonPayload);
                if (payloadData.ContainsKey("clientId"))
                {
                    if (payloadData["clientId"].ToString() == clientId)
                    {
                        //Verificar fechas de expiracion y de creacion
                        var fechaCreacion = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payloadData["iat"].ToString()));
                        var fechaExpiracion = DateTimeOffset.FromUnixTimeSeconds(long.Parse(payloadData["exp"].ToString()));
                        if (DateTime.Now > fechaCreacion && DateTime.Now < fechaExpiracion)
                        {
                            autorizado = true;
                        }
                    }
                }
                if (autorizado)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                else
                {
                    context.Fail();
                    return SetResponseAsync("No autorizado, Token inválido", 401);
                }
            }
            catch(Exception e)
            {
                context.Fail();
                throw new Exception("Error al autorizar", e);
            }
        }
        private Task SetResponseAsync(string message, int statusCode)
        {
            var result = JsonConvert.SerializeObject(new { error = message });
            _httpContextAccessor.HttpContext.Response.OnStarting(() =>
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = statusCode;
                _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);
                return Task.CompletedTask;
            });

            return Task.CompletedTask;
        }   
    }
}

