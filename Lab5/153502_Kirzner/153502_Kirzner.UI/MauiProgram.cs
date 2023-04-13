using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.ApplicationServices.Services;
using _153502_Kirzner.Domain.Abstractions;
using _153502_Kirzner.Persistence.Repository;
using _153502_Kirzner.UI.Pages;
using _153502_Kirzner.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace _153502_Kirzner.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "CourceManager.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        SetupServices(builder.Services);
        return builder.Build();
    }

    private static void SetupServices(IServiceCollection services)
    {
        //Services
        services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
        services.AddSingleton<IEmployeePositionService, EmployeePositionService>();
        services.AddSingleton<IJobDutyService, JobDutyService>();

        //Pages
        services.AddSingleton<EmployeePositions>();

        //ViewModels
        services.AddSingleton<EmployeePositionsViewModel>();
        
    }
}
