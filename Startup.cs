using ExameApi.Models;
using ExameApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace TodoApi
{
	public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        //public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            //.AddEnvironmentVariables();

            //Configuration = builder.Build();
            Configuration = configuration;
        }
        
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            var baseUrl = Environment.GetEnvironmentVariable("ApiBaseUrl");
            var jwtPort = Environment.GetEnvironmentVariable("ApiJwtPort");
            var environmen = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SecurityKey"));
            var DBConnection = Environment.GetEnvironmentVariable("DBConnection");

            services.AddControllers();
            services.AddDbContext<DatabaseContext>(options => options.UseMySQL(DBConnection) );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IContasRepository, ContasRepository>();
            services.AddScoped<ILancamentosRepository, LancamentosRepository>();


            IdentityModelEventSource.ShowPII = true;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;                
            }).AddJwtBearer(options =>
            {
                options.Authority = baseUrl + ":" + jwtPort;
                options.Audience = baseUrl + ":" + jwtPort;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            if (environmen != "producao")
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Seguradora API",
                        Description = "Seguradora ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Waraloo",
                            Email = string.Empty,
                            Url = new Uri("http://waraloo.sites.net"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });

                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
            }
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            var environmen = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seguradora V1");
            });

            app.UseDeveloperExceptionPage();

            app.UseRouting();            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
