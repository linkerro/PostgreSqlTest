using System.Web.Http;
using Newtonsoft.Json;
using Owin;

namespace MonoOwinTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var configuration=new HttpConfiguration();

            configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            builder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            configuration.Routes.MapHttpRoute(
                name: "DafaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
            builder.UseWebApi(configuration);
        }
    }
}
