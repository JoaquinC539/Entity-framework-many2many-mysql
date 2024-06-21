

using PizzaApp.Startup;
using Microsoft.AspNetCore;
using PizzaApp.Context;

// app.Run();

public class Program
{
    public static void Main(string[] args)
    {
        var app= WebHostBuilder(args);

        app.Build().Run();
        
    }

    public static IHostBuilder WebHostBuilder(string [] args)=> 
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
}





