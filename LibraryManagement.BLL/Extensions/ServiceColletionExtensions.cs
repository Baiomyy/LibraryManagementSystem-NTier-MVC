using LibraryManagement.BLL.AuthorManagement.Services;
using LibraryManagement.BLL.BookManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.BLL.Extensions;

public static class ServiceColletionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        //services.AddScoped<IBookTransactionService, BookTransactionService>();
        return services;
    }
}
