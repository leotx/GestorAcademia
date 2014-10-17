using Owin;
using Nancy;

namespace GestorAcademia
{
	public class Module : NancyModule
	{
		public Module ()
		{
			Get ["teste"] = x => {
				return "Teste";
			};
		}
	}
}
