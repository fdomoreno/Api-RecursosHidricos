using System;
using Microsoft.AspNetCore.Authorization;
namespace Api_RecursosHidricos.Politicas.Requerimientos
{
	public class DAutorizarPoliticaRequerimiento : IAuthorizationRequirement
	{
		public DAutorizarPoliticaRequerimiento(string aut)
		{
			autorization = aut;
		}

		public string autorization { get; private set; }
	}
}

