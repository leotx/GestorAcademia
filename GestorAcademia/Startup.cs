using Owin;


namespace GestorAcademia
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.Use((ctx, next) => {
				ctx.TraceOutput.WriteLine(ctx.Request.RemoteIpAddress);

				ctx.Response.Write("OK!!!!!!!!!!");

				return next.Invoke();
			});
		}
	}

}
