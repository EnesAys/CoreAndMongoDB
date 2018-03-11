using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using CoreAndMongoDB.DbModels;
using CoreAndMongoDB.IRepository;
using CoreAndMongoDB.Repository;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace CoreAndMongoDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //   .AddJwtBearer(options =>
            //   {
            //       options.TokenValidationParameters = new TokenValidationParameters
            //       {
            //           ValidateIssuer = true,
            //           ValidateAudience = true,
            //           ValidateLifetime = true,
            //           ValidateIssuerSigningKey = true,
            //           ValidIssuer = "http://localhost:54206/",
            //           ValidAudience = "http://localhost:54206/",
            //           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
            //       };
            //   });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("TrainedStaffOnly",
            //        policy => policy.RequireClaim("CompletedBasicTraining"));
            //});
          
            services.Configure<Settings>(Options =>
            {
                Options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                Options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "My API",
                    Version = "v1",
                    Description =".Net Core 2 Web Api for Mongo DB CRUD Operations",
                    Contact = new Contact { Name = "Enes Aysan", Email = "enesaysan8@gmail.com", Url = "http://enesaysan.com/" },
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "CoreApi.xml");
                c.IncludeXmlComments(xmlPath);
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            //app.UseAuthentication();
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc(routes =>
            {
            routes.MapRoute(
                name: "default",

                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
