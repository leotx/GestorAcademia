using Owin;
using Nancy;

namespace GestorAcademia
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseNancy ();
		}
	}
}
