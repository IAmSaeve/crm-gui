using System;
using System.IO;
using System.Text.Json;
using Avalonia;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace crm_gui;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        Console.WriteLine("Checking for Settings file");
        if (!File.Exists(Constants.SettingsPath))
        {
            Console.WriteLine("Settings file not found, creating a new one.");
            Console.WriteLine($"Settings file location: {Constants.SettingsPath}");
            var data = JsonSerializer.Serialize(new CrmSettings(), Constants.SerializerSettings);
            File.WriteAllText(Constants.SettingsPath, data);
        }

        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}