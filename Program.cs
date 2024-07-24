using MySql.Data.MySqlClient;
using PizzaParty.Models;
using System.Data;

namespace PizzaParty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDbConnection>((s) =>
            {
                IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
                conn.Open();
                return conn;
            });

            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IEventRepository, EventRepository>(); 
            var app = builder.Build();

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
