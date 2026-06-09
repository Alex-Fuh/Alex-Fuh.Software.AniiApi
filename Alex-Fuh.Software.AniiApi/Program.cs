using System.Text.Json.Serialization;
using Alex_Fuh.Software.AniiApi.Services;
using Alex_Fuh.Software.AniiApi.Services.Interfaces;
using Scalar.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        
        //blazor
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                policy
                    .WithOrigins("http://localhost:5156")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        
        
        
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddOpenApi();
        
        builder.Services.AddScoped<ISearchService, SearchService>();
        builder.Services.AddScoped<IDashboardService, DashboardService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        //blazor
        app.UseCors("Frontend");
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapDefaultEndpoints();
        app.MapControllers();

        app.Run();
    }
}