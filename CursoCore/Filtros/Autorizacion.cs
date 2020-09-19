
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoCore.Filtros
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false)]
    public class Autorizacion: AuthorizeAttribute
    {
		private int idOperacion;
		public Autorizacion(int idOperacion = 0)
		{	
			this.idOperacion = idOperacion;
		}

		

			

    }
}
