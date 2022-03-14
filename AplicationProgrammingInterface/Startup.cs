using AccesoDatos.Models;
using AccesoDatos.Repositorio;
using Dominio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Servicio;

namespace AplicationProgrammingInterface
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AplicationProgrammingInterface", Version = "v1" });
            });
           
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();
            services.AddTransient<ICuentaRepositorio, CuentaRepositorio>();
            services.AddTransient<ICuentaServicio, CuentaServicio>();
            services.AddTransient<IMovimientoRepositorio, MovimientoRepositorio>();
            services.AddTransient<IMovimientoServicio, MovimientoServicio>();

            services.AddDbContext<BDAppInterfaceContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Conexion"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AplicationProgrammingInterface v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
