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
			var usuarioRepository = new UsuarioRepository();

			Post["/usuario"] = x => {
				var usuarioDto = this.Bind<UsuarioDto>();

				var usuario = Usuario.Create(usuarioDto.Nome);

				usuarioRepository.Save(usuario);

				return new Response
				{
					StatusCode = HttpStatusCode.Created
				};
			};

			Get ["/usuario/{nomeUsuario}"] = x => {
				string  nomeUsuario = x.nomeUsuario;

				var usuario = usuarioRepository.FindUsuarioByNome(nomeUsuario);

				return usuario;
			};
		}

	}
}
