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
            ProfitDistributionContext context = new ProfitDistributionContext(Configuration["FirebaseConection:AuthSecret"], Configuration["FirebaseConection:BasePath"]);
            services.AddSingleton(context);
            services.AddTransient<IRepository<Employee>, RepositoryFirebase<Employee>>();
            services.AddTransient<IParticipationServices, ParticipationServices>();
            services.AddTransient<IReportServices, ProfitDistributionReportServices>(); 
            services.AddTransient<IEmployeeServices, EmployeeServices>();
            services.AddSingleton(AutoMapperSet());
            var minimalSalary = Decimal.Parse(Configuration["MinimalSalary"]);
            services.AddSingleton(new SalaryServices(minimalSalary));
            services.AddSingleton(new SalaryServices(minimalSalary));

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
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Distribui��o de Lucros Api", 
                    Description = "Api de Distribui��o dos lucros respons�vel recuperar/cadastrar/deletar/atualizar funcion�rio(Employee), al�m realizar um relat�rio de distribui��o de lucros(ProfitDistribuitionReport) com base no total o que a empresa pretende disponibilizar para distribuir de lucros",
                    Version = "1.0" 
                });
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

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IMapper AutoMapperSet()
        {
            var provider = new CultureInfo("pt-BR");
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<EmployeeDTO, Employee>()
                        .ForMember(d => d.Salario_bruto,
                        s => s.MapFrom(s => Decimal.Parse(s.Salario_Bruto, NumberStyles.Currency, provider)))
                    .ReverseMap()
                    .ForMember(d => d.Salario_Bruto,
                        s => s.MapFrom(s => s.Salario_bruto.ToString("C2", provider)));

                    config.CreateMap<Participation, ParticipationDTO>().ForMember(d => d.valor_da_participacao,
                        s => s.MapFrom(s => s.Valor_da_participacao.ToString("C2", provider)));

                    config.CreateMap<ProfitDistributionReport, ProfitDistributionReportDTO>()
                        .ForMember(d => d.total_disponibilizado,
                            s => s.MapFrom(s => s.Total_disponibilizado.ToString("C2", provider)))
                        .ForMember(d => d.total_distribuido,
                            s => s.MapFrom(s => s.Total_distribuido.ToString("C2", provider)))
                        .ForMember(d => d.saldo_total_disponibilizado,
                            s => s.MapFrom(s => s.Saldo_total_disponibilizado.ToString("C2", provider)))
                        .ForMember(d => d.total_de_funcionarios,
                            s => s.MapFrom(s => s.Total_de_funcionarios.ToString()));
                }

            );
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
