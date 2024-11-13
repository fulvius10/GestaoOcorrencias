using GestaoOcorrencias.Application.Services;
using GestaoOcorrencias.Domain.Interfaces;
using GestaoOcorrencias.Infrastructure.Data;
using GestaoOcorrencias.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GestaoOcorrencias
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Registra os repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

            // Registra os serviços
            services.AddScoped<ClienteService>();
            services.AddScoped<OcorrenciaService>();

            // Adiciona suporte ao Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestão de Ocorrências API",
                    Version = "v1",
                    Description = "API para gerenciamento de ocorrências e clientes"
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Rota pro swagger
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestão de Ocorrências API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
