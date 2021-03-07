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
using ProfitDistribution.Infrastructure;
using ProfitDistribution.Services;
using ProfitDistribution.Services.Handlers;
using System;
using System.Globalization;

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
            DistributionProfitContext context = new DistributionProfitContext(Configuration["FirebaseConection:AuthSecret"], Configuration["FirebaseConection:BasePath"]);
            services.AddSingleton(context);
            services.AddTransient<IRepository<Employee>, RepositoryFirebase<Employee>>();
            services.AddTransient<IParticipationServices, ParticipationServices>();
            AutoMapperSet(ref services);


            //services.AddApiVersioning(options =>
            //    options.ApiVersionReader = ApiVersionReader.Combine(
            //        new HeaderApiVersionReader("api-version"),
            //        new QueryStringApiVersionReader("api-version")
            //    )
            //);

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

        private void AutoMapperSet(ref IServiceCollection services)
        {
            var provider = new CultureInfo("pt-BR");
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
                config.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(employee => employee.salario_bruto, 
                    employeeDTO => employeeDTO.MapFrom(s => Decimal.Parse(s.salario_bruto, NumberStyles.Currency, provider)))
            );
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }


    public class DecimalTypeConverter : ITypeConverter<string, decimal>
    {
        public decimal Convert(string source, decimal destination, ResolutionContext context)
        {
            return Decimal.Parse(source, NumberStyles.Currency, CultureInfo.InvariantCulture);
        }
    }

    public class DecimalValueConverter : IValueConverter<string, decimal>
    {
        public decimal Convert(string sourceMember, ResolutionContext context)
        {
            return 0.00M;
        }
    }



}
