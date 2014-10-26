using Owin;
using Nancy;
using MongoDB.Driver;
using System;
using Nancy.ModelBinding;
using MongoDB.Driver.Builders;

namespace GestorAcademia
{
	public class Module : NancyModule
	{
		public Module ()
		{
			Post["/usuario"] = x => {
				var usuarioDto = this.Bind<UsuarioDto>();

				var usuario = Usuario.Create(usuarioDto.Nome);

				var client = new MongoClient ();
				var db = client.GetServer().GetDatabase ("GestorAcademia");
				var collection = db.GetCollection ("usuario");
				collection.Save (usuario);

				return new Response
				{
					StatusCode = HttpStatusCode.OK
				};
			};
		}
	}
}
