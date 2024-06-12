using System;
using Api_RecursosHidricos.Politicas;
using Api_RecursosHidricos.AppContext;
using Api_RecursosHidricos.Repository;
using Api_RecursosHidricos.Repository.Impl;
using Api_RecursosHidricos.Services;
using Api_RecursosHidricos.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Api_RecursosHidricos.Politicas.Requerimientos;

namespace Api_RecursosHidricos
{
    public class Startup
    {
        /*
         * 
         * // Add services to the container
         * */
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRecursosHidricosService, RecursosHidricosService>();
            services.AddScoped<IRecursoHidricoRepository, RecursoHidricoRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationHandler, DAutorizarHandler>();
            services.AddTransient<IAuthorizationPolicyProvider, DAutorizarPoliticaProvider>();
            services.AddAuthentication();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = BearerTokenDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = BearerTokenDefaults.AuthenticationScheme;

            }).AddBearerToken();
            services.AddHttpContextAccessor();
            services.AddCors();
        }
    }
}

