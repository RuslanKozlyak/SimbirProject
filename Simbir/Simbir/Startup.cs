using AutoMapper;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Mapping;
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

        /// <summary>
        /// Часть 2 п 1 Подключить при помощи ef базу данных к проекту
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Repository")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IHumanService, HumanService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAuthorService, AuthorService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthorMap());
                mc.AddProfile(new BookMap());
                mc.AddProfile(new GenreMap());
                mc.AddProfile(new HumanMap());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simbir", Version = "v1" });
            });

        }

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
