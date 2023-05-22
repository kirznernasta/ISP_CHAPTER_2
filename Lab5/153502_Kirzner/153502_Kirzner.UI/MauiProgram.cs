using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.ApplicationServices.Services;
using _153502_Kirzner.Domain.Abstractions;
using _153502_Kirzner.Domain.Entities;
using _153502_Kirzner.Persistence.Data;
using _153502_Kirzner.Persistence.Repository;
using _153502_Kirzner.UI.Pages;
using _153502_Kirzner.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace _153502_Kirzner.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "_153502_Kirzner.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

        SetupServices(builder.Services);
        AddDbContext(builder);
        SeedData(builder.Services);
        return builder.Build();
    }

    private static void SetupServices(IServiceCollection services)
    {
        //Services
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        services.AddSingleton<IEmployeePositionService, EmployeePositionService>();
        services.AddSingleton<IJobDutyService, JobDutyService>();

        //Pages
        services.AddSingleton<EmployeePositions>();
        services.AddTransient<JobDutyDetails>();
        services.AddTransient<ManagingDuty>();
        services.AddTransient<ManagingEmployeePosition>();

        //ViewModels
        services.AddSingleton<EmployeePositionsViewModel>();
        services.AddTransient<JobDutyDetailsViewModel>();
        services.AddTransient<ManagingDutyViewModel>();
        services.AddTransient<ManagingEmployeePositionViewModel>();

    }

    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connStr = builder.Configuration
        .GetConnectionString("SqliteConnection");
        string dataDirectory = String.Empty;

        #if ANDROID
        dataDirectory = FileSystem.AppDataDirectory + "/";
        #endif

        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()

        .UseSqlite(connStr)
        .Options;

        builder.Services.AddSingleton<AppDbContext>((s) =>
        new AppDbContext(options));
    }

    public async static void SeedData(IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var unitOfWork = provider.GetService<IUnitOfWork>();
        
        await unitOfWork.RemoveDatbaseAsync();
        await unitOfWork.CreateDatabaseAsync();

        IReadOnlyList<EmployeePosition> employeePositions = new List<EmployeePosition>() 
        { 
        new EmployeePosition{ Name= "Consultant", Salary=1000},
        new EmployeePosition{Name = "Waiter", Salary = 1500}
        };
        foreach (var employeePosition in employeePositions)
            await unitOfWork.EmployeePositionRepository.AddAsync(employeePosition);

        await unitOfWork.SaveAllAsync();

        Random rand = new Random();
        int k = 1;

        foreach (var employeePosition in employeePositions)
            for (int j = 0; j < 10; j++)
                await unitOfWork.JobDutyRepository.AddAsync(new JobDuty()
                {
                    Name = $"Job duty {k++}",
                    Description = $"some description about job duty of {employeePosition.Name}",
                    Experience = rand.Next() % 30,
                    DutyImportance = (rand.Next() + 7) % 10 + 1,
                    EmployeePositionId = employeePosition.Id,
                }) ;
        await unitOfWork.SaveAllAsync();
    }
}
