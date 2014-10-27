using Owin;
using Nancy;
using MongoDB.Driver;
using System;
using Nancy.ModelBinding;
using MongoDB.Driver.Builders;
using Mono.CSharp;

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

			Get ["/usuario/{nomeUsuario}"] = x => {
				string  nomeUsuario = x.nomeUsuario;

				var client = new MongoClient ();
				var db = client.GetServer().GetDatabase ("GestorAcademia");
				var collection = db.GetCollection ("usuario");
				var query = Query<Usuario>.EQ(e => e.Nome, nomeUsuario);
				var entity = collection.FindOne(query);

				return entity;
			};
		}
	}
}
