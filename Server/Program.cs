using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Server.AI;
using Server.AI.Methods;
using Server.Services;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var currentDirectory = Directory.GetCurrentDirectory();
        var possibleAppSettingLocations = new[]
        {
            Path.Combine(currentDirectory, "appsettings.json"),
            Path.Combine(currentDirectory, "..", "appsettings.json"),
            Path.Combine(currentDirectory, "..", "..", "appsettings.json"),
            Path.Combine(currentDirectory, "..", "..", "..", "appsettings.json"),
            Path.Combine(currentDirectory, "..", "..", "..", "..", "appsettings.json"),
            Path.Combine(currentDirectory, "..", "..", "..", "..", "..", "appsettings.json"),
            Path.Combine(currentDirectory, "..", "..", "..", "..", "..", "..", "appsettings.json")
        };

        builder.Configuration.SetBasePath(currentDirectory);
        builder.Configuration.AddEnvironmentVariables();

        var foundAppSetting = false;
        foreach (var possibleAppSettingLocation in possibleAppSettingLocations)
            if (File.Exists(possibleAppSettingLocation))
            {
                foundAppSetting = true;
                builder.Configuration.AddJsonFile(possibleAppSettingLocation, false, true);
                break;
            }

        if (!foundAppSetting) throw new FileNotFoundException("Could not find appsettings.json");


        builder.Logging.AddConsole();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<IUserLanguageService, UserLanguageService>();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //options.JsonSerializerOptions.IgnoreNullValues = true;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.Configure<AppConfiguration>(builder.Configuration);

        builder.Services.AddSingleton<SemanticKernelProvider>();
        builder.Services.AddSingleton<MethodChainOfThought>();
        builder.Services.AddSingleton<CommonMethods>();
        builder.Services.AddSingleton<EAN13Method>();
        builder.Services.AddSingleton<PromptTechniques>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseAuthorization();

        app.UseCors("AllowAll");
        app.MapControllers();

        app.Run();
    }
}