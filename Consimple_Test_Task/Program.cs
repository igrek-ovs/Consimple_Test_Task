using Consimple_Test_Task.Api.DI;
using Consimple_Test_Task.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Consimple_Test_Task.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddApplicationServices(connectionString);

        builder.Services.AddAuthorization();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.MapControllers();

        app.UseAuthorization();

        app.Run();
    }
}