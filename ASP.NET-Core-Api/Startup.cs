namespace ASP.NET_Core_Api
{
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Newtonsoft.Json;
    using Domain;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("netCore")); 

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => IdentityOptions(options))
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = TokenValidationParameters());

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(ConfigureJson);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Example - My First API",
                    Description = "My First ASP.NET Core 2.1 Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "jorgemht", Email = "#", Url = "#" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureJson(MvcJsonOptions obj) => obj.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        private TokenValidationParameters TokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key_Secret"])),
                ClockSkew = TimeSpan.Zero
            };
        }

        private IdentityOptions IdentityOptions(IdentityOptions obj)
        {
            // Password settings
            obj.Password.RequireDigit = false;
            obj.Password.RequiredLength = 6;
            obj.Password.RequiredUniqueChars = 0;
            obj.Password.RequireLowercase = false;
            obj.Password.RequireNonAlphanumeric = false;
            obj.Password.RequireUppercase = false;

            return obj;
        }

    }
}
