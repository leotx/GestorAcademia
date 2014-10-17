using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Microsoft.Owin.Hosting;

namespace GestorAcademia
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			var httplocalhost = "http://localhost:9000";
			using(WebApp.Start<Startup> (httplocalhost))
			{
				Console.WriteLine ("Listening on " + httplocalhost);
				Console.WriteLine ("press [Enter] to finish... ");
				Console.Read ();
			}

			//TestMongoDb ();







		}

		static void TestMongoDb ()
		{
			var client = new MongoClient ();
			var db = client.GetServer ().GetDatabase ("Gestor");
			var collection = db.GetCollection ("testCollection");
			var model = new Model {
				Id = Guid.NewGuid (),
				Name = "ABC",
				Age = 10
			};
			collection.Save (model);
			var query = Query<Model>.EQ (e => e.Id, model.Id);
			var entity = collection.FindOne (query);
			Console.WriteLine (entity.ToString ());
		}
	}
}
