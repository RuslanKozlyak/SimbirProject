using Domain.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddAuthorService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
        }

        public static void AddGenreService (this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
        }

        public static void AddBookService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }

        public static void AddHumanService(this IServiceCollection services)
        {
            services.AddScoped<IHumanService, HumanService>();
        }
    }
}
