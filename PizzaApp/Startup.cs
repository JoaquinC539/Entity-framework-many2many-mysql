
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Context;
using Services.SauceService;

namespace PizzaApp.Startup;
public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        if(env.IsDevelopment())
        {
            Env.Load();
            Environment.SetEnvironmentVariable("MYSQL_SERVER",Env.GetString("MYSQL_SERVER"));
            Environment.SetEnvironmentVariable("MYSQL_USER",Env.GetString("MYSQL_USER"));
            Environment.SetEnvironmentVariable("MYSQL_PASSWORD",Env.GetString("MYSQL_PASSWORD"));
            Environment.SetEnvironmentVariable("MYSQL_DATABASE",Env.GetString("MYSQL_DATABASE"));
        }

    }
    public void Configureservices(IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        
        var server=Environment.GetEnvironmentVariable("MYSQL_SERVER");
        var user=Environment.GetEnvironmentVariable("MYSQL_USER");
        var password=Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        var db=Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        var connectionString=$"server={server};port=3306;user={user};password={password};database={db}";

        var serverVersion=new MySqlServerVersion(new Version(8,0,29));

        services.AddMySql<PizzaAppContext>(connectionString,serverVersion);

        services.AddScoped<SauceService>();
        
    }
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            // endpoints.MapGet("/",async context=>
            // {
            //     Dictionary<string,string> map = new Dictionary<string,string> {{"Message","Person and employees head to /swagger/index.html to see operations or api/ endpoints to use the app"}};                
            //     context.Response.StatusCode=200;
            //     await context.Response.WriteAsJsonAsync(map);
            // });
            app.MapWhen(context=>context.Response.StatusCode == 404,(appBuilder)=>
            {
               appBuilder.Run(async context=>
               {
                context.Response.StatusCode=404;
                await context.Response.WriteAsJsonAsync("Resource Not found");
               }); 
            });

        });

        
    }
}