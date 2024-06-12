using System;
using Microsoft.AspNetCore.Authorization;
namespace Api_RecursosHidricos.Atributos
{
	public class DAutorizarAttribute : AuthorizeAttribute
    {
		public string SgaAutorizacion
		{
			get
			{
				return SgaAutorizacion;

            }
			set
			{
				Policy = value.ToString();
			}
		}
		public DAutorizarAttribute(string sgaAutirzacion) => SgaAutorizacion = sgaAutirzacion;
    }
}

