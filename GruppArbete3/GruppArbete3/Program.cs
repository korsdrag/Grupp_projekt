using EmployeesProj.Models.Entities;
using EmployeesProj.Models;
using Microsoft.EntityFrameworkCore;

namespace GruppArbete3
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<EmployeeService>();
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EmployeesContext>(o => o.UseSqlServer(connString));
            var app = builder.Build();
            app.UseRouting()
               .UseEndpoints(endpoints => endpoints.MapControllers())
               .UseStaticFiles();
            app.Run();
        }
    }
}