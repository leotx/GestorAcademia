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
		}
	}
}
