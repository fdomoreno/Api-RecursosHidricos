using System;
using Api_RecursosHidricos.Politicas.Requerimientos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Api_RecursosHidricos.Politicas
{
	public class DAutorizarPoliticaProvider : IAuthorizationPolicyProvider
    {

        private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }

        public DAutorizarPoliticaProvider(IOptions<AuthorizationOptions> options)
		{
            BackupPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy>(null);

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            string politica = policyName;
            if (!string.IsNullOrEmpty(politica))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new DAutorizarPoliticaRequerimiento(policyName));
                return Task.FromResult(policy.Build());
            }

            return BackupPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}

