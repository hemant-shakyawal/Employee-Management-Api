using Employee_Management_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Employee_Management_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(

                options => options.UseInMemoryDatabase("EmployeeDb")
                );

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
