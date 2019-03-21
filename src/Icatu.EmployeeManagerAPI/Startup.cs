using AutoMapper;
using Icatu.EmployeeManagerAPI.Core.Contexts;
using Icatu.EmployeeManagerAPI.Extension;
using Icatu.EmployeeManagerAPI.Infrastructure;
using Icatu.EmployeeManagerAPI.Middleware;
using Icatu.EmployerManagerAPI.Core.Interfaces;
using Icatu.EmployerManagerAPI.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;

namespace Icatu.EmployeeManagerAPI
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
            services.AddMvc()
                .AddFluentValidation(fvc =>
                            fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper();
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings:SQLConnection").Value));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = Configuration.GetSection("Swagger:Version").Value,
                    Title = Configuration.GetSection("Swagger:Title").Value,
                    Description = Configuration.GetSection("Swagger:Description").Value,
                    TermsOfService = "",
                    Contact = new Contact() { Name = Configuration.GetSection("Swagger:Contact:Name").Value,
                                              Email = Configuration.GetSection("Swagger:Contact:Email").Value,
                                              Url = Configuration.GetSection("Swagger:Contact:Url").Value
                    }
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

            app.UseMvc();
            app.UseExceptionMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Configuration.GetSection("Swagger:Version").Value} - {Configuration.GetSection("Swagger:Title").Value}");
            });
        }
    }
}
