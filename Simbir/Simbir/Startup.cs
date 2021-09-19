using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Interfaces;
using Simbir.Middleware;

namespace Simbir
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
            /// <summary>
            /// Часть 2 п 1 Подключить при помощи ef базу данных к проекту
            /// </summary>
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Simbir")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IHumanService, HumanService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookGenreService, BookGenreService>();
            services.AddTransient<ILibraryCardService, LibraryCardService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simbir", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<LoggerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simbir v1"));
            }
            //app.UseMiddleware<AuthorizationMiddleware>();

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
