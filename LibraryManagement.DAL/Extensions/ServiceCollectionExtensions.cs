using LibraryManagement.DAL.AuthorManagement.Repositories;
using LibraryManagement.DAL.BookManagement.Repositories;
using LibraryManagement.DAL.BookTransactionManagement.Repositories;
using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseInMemoryDatabase("LibraryDb"));

        // Register all seeders as IEnumerable<IDbSeeder>
        services.AddScoped<IDbSeeder, AuthorSeeder>();
        services.AddScoped<IDbSeeder, BookSeeder>();
        services.AddScoped<IDbSeeder, BookTransactionSeeder>();

        // Register DbSeeder which runs them
        services.AddScoped<DbSeeder>();

        // Register repositories
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookTransactionRepository, BookTransactionRepository>();

        return services;

    }
}
