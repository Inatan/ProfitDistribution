using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Filter;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            AutoMapperSet(services);

            services.AddApiVersioning(options =>
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("api-version"),
                    new QueryStringApiVersionReader("api-version")
                )
            );

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorResponseFilter));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Distirbuição de Lucros Api", Description = "Documentação da API", Version = "1.0" });
                c.EnableAnnotations();
                c.DocumentFilter<TagDescriptionsDocumentFilter>();

            });
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMapperSet(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
                config.CreateMap<EmployeeDTO, Employee>()
            );
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
