using MyWebServer.Http;
using MyWebServer.Controllers;

namespace Andreys.App.Controllers
{

    public class HomeController : Controller
    {
        public HttpResponse Index()
        { 
            return this.View();
        }
    }
}
