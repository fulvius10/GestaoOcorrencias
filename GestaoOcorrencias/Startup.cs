using GestaoOcorrencias.Application.Services;
using GestaoOcorrencias.Domain.Interfaces;
using GestaoOcorrencias.Infrastructure.Data;
using GestaoOcorrencias.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

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

            services.AddControllersWithViews();
        }
    }
}
