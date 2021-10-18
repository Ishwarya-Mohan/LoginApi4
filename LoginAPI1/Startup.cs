using LoginAPI1.ELearnModel;
using LoginAPI1.Provider;
using LoginAPI1.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAPI1.Service;

namespace LoginAPI1
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
            // Auto Mapper Configurations
           
            services.AddMvc();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LoginAPI1", Version = "v1" });
            });
            services.AddScoped<IUserAccount<UserAccount>, UserAccount>();
            services.AddScoped<IUserAccountRepo<UserAccount>, UserAccountRepo>();
            services.AddScoped<IUserAccountServ<UserAccount>, UserAccountServ>();
            services.AddScoped<IAuthProvider<UserAccount>, AuthProvider>();

            services.AddScoped<IAddRequestRepo<NewStaff>, AddRequestRepo>();
            services.AddScoped<IAddRequestService<NewStaff>, AddRequestService>();
            services.AddScoped<INewStaff<NewStaff>, NewStaff>();

            services.AddScoped<IAddContactService<Contact>, AddContactService>();
            services.AddScoped<IAddContactRepo<Contact>, AddContactRepo>();
            services.AddScoped<IContact<Contact>, Contact>();

            
            


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddCors();
            services.AddDbContext<ELearnApp1Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginAPI1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options => options.WithOrigins().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
