using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PFSS.API.Config;
using PFSS.Models;
using PFSS.Services.Wrapper;

namespace PrivateFileStorageService
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
            services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
            services.AddSingleton<IJwtSettings>(x => x.GetRequiredService<IOptions<JwtSettings>>().Value);
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<ServiceWrapper>();
            services.AddControllers();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "PrivateFileStorageService",
                    Version = "v1",   
                });

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

                swagger.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "PFSS.API.xml"));

            });
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfig());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           // Adding Jwt Bearer  
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = Configuration["jwt:ValidAudience"],
                   ValidIssuer = Configuration["jwt:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:Secret"]))
               };
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrivateFileStorageService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
