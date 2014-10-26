using Owin;
using Nancy;
using System;

namespace GestorAcademia
{
	public class Usuario	{
		public Guid Id {get; private set;}
		public string Nome { get; set;}

		public static Usuario Create (string nome)
		{
			var Usuario = new Usuario {
				Id = Guid.NewGuid(),
				Nome = nome
			};

			return Usuario;
		}
	}
}
