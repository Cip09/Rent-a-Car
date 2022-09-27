
using DatabaseClass;
using DB.DTO;
using DB.Entities;
using DB.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using API.SingleR;
using DB.Services.Interface;

namespace AuthServer
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


            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

         //   services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            //services.AddDefaultIdentity<User>()
            //.AddEntityFrameworkStores<DatabaseContext>();

            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<DatabaseContext>()
               .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            //services.AddCors();

            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });




            services.AddSignalR();

            services.AddTransient<ISmartSenzorServices, SmartSenzorServices>();
            services.AddTransient<ISmartDeviceServices, SmartDeviceServices>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IRentScheduling, RentSchedulingService>();
            services.AddTransient<IUserHistoryService, UserHistoryService>();

            //services.AddCors(options => options.AddPolicy("AllowAll", p => p.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            //   .AllowAnyMethod()
            //   .AllowAnyHeader()));
            services.AddCors();
            services.AddControllersWithViews();
            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //}).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "UI/dist";
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<API.SingleR.SignalHub>("/stockChangesHub");

            });

        /*    app.Map("/CoordinatorHub/negotiate", map =>
            {
                map.UseCors("CorsPolicy");
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // EnableDetailedErrors = true,
                    // EnableJSONP = true

                };
                map.RunSignalR(hubConfiguration);
            });*/
            /*
                       app.UseSpa(spa =>
                        {
                            // To learn more about options for serving an Angular SPA from ASP.NET Core,
                            // see https://go.microsoft.com/fwlink/?linkid=864501

                            spa.Options.SourcePath = "UI";

                            if (env.IsDevelopment())
                            {
                                spa.UseAngularCliServer(npmScript: "start");
                            }
                        });*/






            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}


            //app.UseCors("CorsPolicy");
            app.UseCors(x => x
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader());


            //app.UseStaticFiles();
            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}
            //app.UseHttpsRedirection();


            ////app.UseCors(builder =>
            ////builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            ////.AllowAnyHeader()
            ////.AllowAnyMethod()

            ////);

            //app.UseAuthentication();
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action=Index}/{id?}");
            //});
            /*        app.UseSpa(spa =>
                    {
                        // To learn more about options for serving an Angular SPA from ASP.NET Core,
                        // see https://go.microsoft.com/fwlink/?linkid=864501

                        spa.Options.SourcePath = "UI";

                        if (env.IsDevelopment())
                        {
                            spa.UseAngularCliServer(npmScript: "start");
                        }
                    });
        */
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
