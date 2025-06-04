using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagement.BLL.AuthorManagement.Validators;
using LibraryManagement.BLL.Extensions;
using LibraryManagement.DAL.Extensions;
using LibraryManagement.DAL.Persistence;

namespace LibraryManagement.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register layers
            builder.Services.AddInfrastructure(); // Repos + DbContext
            builder.Services.AddApplication();    // Business Services

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<AuthorValidator>();


            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
                seeder.SeedAll(db);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
