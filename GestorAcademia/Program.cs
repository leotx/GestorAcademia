using System;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace GestorAcademia
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			var client = new MongoClient();

			var db = client.GetServer ().GetDatabase("Gestor");

			var collection = db.GetCollection ("testCollection");

			var model = new Model {
				Id = Guid.NewGuid(),
				Name = "ABC",
				Age = 10
			};

			collection.Save (model);

			var query = Query<Model>.EQ(e => e.Id, model.Id);
			var entity = collection.FindOne(query);

			Console.WriteLine (entity.ToString());

		}
	}
}
