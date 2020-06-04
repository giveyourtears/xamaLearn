using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using xamApi.Helpers;
using xamApi.Services;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace xamApi
{
  public class Startup
  {
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
      _env = env;
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DataContext>();

      services.AddCors();
      services.AddControllers();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      var appSettingsSection = _configuration.GetSection("AppSettings");
      services.Configure<SecretSettings>(appSettingsSection);

      // jwt
      var appSettings = appSettingsSection.Get<SecretSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
       .AddJwtBearer(x =>
       {
         x.Events = new JwtBearerEvents
         {
           OnTokenValidated = context =>
           {
             var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
             var userId = int.Parse(context.Principal.Identity.Name);
             var user = userService.GetById(userId);
             if (user == null)
             {
               // return unauthorized if user no longer exists
               context.Fail("Unauthorized");
             }
             return Task.CompletedTask;
           }
         };
         x.RequireHttpsMetadata = false;
         x.SaveToken = true;
         x.TokenValidationParameters = new TokenValidationParameters
         {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false
         };
       });

      // dependency injection
      services.AddScoped<IUserService, UserService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
    {
      dataContext.Database.Migrate();

      app.UseRouting();

      app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}