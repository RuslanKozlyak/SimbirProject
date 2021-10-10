using Domain.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Service
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddAuthorRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        public static void AddGenreRepository(this IServiceCollection services)
        {
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static void AddBookRepository(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public static void AddHumanRepository(this IServiceCollection services)
        {
            services.AddScoped<IHumanRepository, HumanRepository>();
        }

        public static void AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
