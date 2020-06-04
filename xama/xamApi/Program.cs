using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace xamApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      OnCreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder OnCreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
