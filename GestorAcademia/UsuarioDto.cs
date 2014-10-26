using Owin;
using Nancy;
using MongoDB.Driver;
using System;
using Nancy.ModelBinding;
using MongoDB.Driver.Builders;

namespace GestorAcademia
{
	public class UsuarioDto
	{
		public string Nome { get; set; }
	}
}
