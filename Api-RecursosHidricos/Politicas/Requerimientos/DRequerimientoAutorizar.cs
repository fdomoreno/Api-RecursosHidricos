using System;
using Microsoft.AspNetCore.Authorization;
namespace Api_RecursosHidricos.Politicas.Requerimientos
{
	public class DRequerimientoAutorizar : IAuthorizationRequirement
    {
        public string SgaAutorization { get; private set; }

        public DRequerimientoAutorizar(string sgaAutorization)
		{
            SgaAutorization = sgaAutorization;
        }
	}
}

