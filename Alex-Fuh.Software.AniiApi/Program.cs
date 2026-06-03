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

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddOpenApi();
        
        builder.Services.AddScoped<ISearchService, SearchService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapDefaultEndpoints();
        app.MapControllers();

        app.Run();
    }
}