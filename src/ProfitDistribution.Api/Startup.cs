using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
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
            
            services.AddCors();
            
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorResponseFilter));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddApiVersioning(options =>
                 options.ApiVersionReader = ApiVersionReader.Combine(
                     new HeaderApiVersionReader("api-version"),
                     new QueryStringApiVersionReader("api-version")
                 )
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Inatan L. Hertzog",
                        Email = "inatan.hertzog@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/inatan-hertzog/"),
                    }
                });

                c.EnableAnnotations();
                c.DocumentFilter<ApiDocumentFilter>();
            });
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IMapper AutoMapperSet()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<EmployeeDTO, Employee>()
                        .ForMember(d => d.Salario_bruto,
                        s => s.MapFrom(s => Decimal.Parse(s.GrossSalary, NumberStyles.Currency))) // Here
                        .ForMember(d => d.Matricula,
                        s => s.MapFrom(s => s.RegistrationId))
                        .ForMember(d => d.Area,
                        s => s.MapFrom(s => s.OccupationArea))
                        .ForMember(d => d.Cargo,
                        s => s.MapFrom(s => s.Office))
                        .ForMember(d => d.Data_de_admissao,
                        s => s.MapFrom(s => s.AdmissionDate))
                        .ForMember(d => d.Nome,
                        s => s.MapFrom(s => s.Name))
                    .ReverseMap()
                    .ForMember(d => d.GrossSalary,
                        s => s.MapFrom(s => s.Salario_bruto.ToString("C2")));

                    config.CreateMap<Participation, ParticipationDTO>()
                        .ForMember(d => d.ParticiapationValue,
                            s => s.MapFrom(s => s.ParticipationValue.ToString("C2")));

                    config.CreateMap<ProfitDistributionReport, ProfitDistributionReportDTO>()
                        .ForMember(d => d.AvailableTotal,
                            s => s.MapFrom(s => s.AvailableTotal.ToString("C2")))
                        .ForMember(d => d.DistributedTotal,
                            s => s.MapFrom(s => s.DistributedTotal.ToString("C2")))
                        .ForMember(d => d.AvailableTotalBalace,
                            s => s.MapFrom(s => s.AvailableTotalBalace.ToString("C2")))
                        .ForMember(d => d.EmployeeTotal,
                            s => s.MapFrom(s => s.EmployeeTotal.ToString()));
                }

            );
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
