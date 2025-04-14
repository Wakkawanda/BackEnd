using Microsoft.OpenApi.Models;

namespace BackEndWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Добавляем CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
        });

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
            });
        }

        app.UseHttpsRedirection();

        // Включаем CORS
        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}