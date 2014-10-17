using System;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson;

namespace GestorAcademia
{
	public class Model
	{

		public Guid Id {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public int Age {
			get;
			set;
		}
	}

}
