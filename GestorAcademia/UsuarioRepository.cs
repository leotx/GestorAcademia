using Owin;
using Nancy;
using MongoDB.Driver;
using System;
using Nancy.ModelBinding;
using MongoDB.Driver.Builders;
using Mono.CSharp;

namespace GestorAcademia
{
	public class UsuarioRepository
	{
		MongoCollection<MongoDB.Bson.BsonDocument> collection;
		MongoDatabase db;
		string _gestorAcademia;

		private MongoCollection<MongoDB.Bson.BsonDocument> Connect ()
		{
			var client = new MongoClient ();
			db = client.GetServer ().GetDatabase (_gestorAcademia);
			var collection = db.GetCollection ("usuario");


			return collection;
		}

		public UsuarioRepository (string gestorAcademia = "GestorAcademia")
		{
			_gestorAcademia = gestorAcademia;
			collection = Connect ();
		}

		public Usuario FindUsuarioByNome (string nomeUsuario)
		{
			var query = Query<Usuario>.EQ(e => e.Nome, nomeUsuario);
			return collection.FindOne(query);
		}

		public Usuario Save (Usuario usuario)
		{
			collection.Save (usuario);
		}
	}
}
