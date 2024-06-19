

using PizzaApp.Startup;
using Microsoft.AspNetCore;

// app.Run();

public class Program
{
    public static void Main(string[] args)
    {
        var app= WebHostBuilder(args);

        app.Build().Run();
        
    }

    public static IWebHostBuilder WebHostBuilder(string [] args)=> 
    WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>();
}





