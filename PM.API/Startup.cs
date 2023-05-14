using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PM.DATABASE.Infrastructure;
using PM.DATABASE.Repository;
using PM.SERVICE.IServices;
using PM.SERVICE.Services;
using Microsoft.OpenApi.Models;
using PM.DATABASE;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PM.API.CustomFilters;
using PM.API.Infrastructure.CustomFilters;

namespace PM.API
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ModelStateValidationFilter());
                options.Filters.Add(new ResultFilter());
                options.Filters.Add(new ExceptionFilter());
            });

            services.AddControllers();
            services.AddDbContext<MasterDBContext>(options => options.UseSqlServer(ConnectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "my_issuer",
                    ValidAudience = "my_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Thisissecuritykey"))
                };
            });

            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crud.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert TOken",
                    Name = "Authorize",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
             {
                 new OpenApiSecurityScheme
                 {
                     Reference=new OpenApiReference
                     {
                         Type=ReferenceType.SecurityScheme,
                         Id="Bearer"
                     }
                 },
                 new string[]{}
             }
            });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
