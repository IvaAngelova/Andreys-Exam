using System.Threading.Tasks;

using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Microsoft.EntityFrameworkCore;

using Andreys.Data;
using Andreys.Services;

namespace Andreys.App
{
    public class StartUp
    {
        public static async Task Main()
             => await HttpServer.WithRoutes(routes => routes
                 .MapStaticFiles()
                 .MapControllers())
             .WithServices(services => services
                 .Add<IViewEngine, CompilationViewEngine>()
                 //.Add<IValidator, Validator>()
                 .Add<IPasswordHasher, PasswordHasher>()
                 .Add<AndreysDbContext>())
                 .WithConfiguration<AndreysDbContext>(context => context.Database.Migrate())
             .Start();
    }
}
