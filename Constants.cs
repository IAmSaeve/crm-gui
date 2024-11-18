using System;
using System.IO;
using System.Text.Json;

namespace crm_gui;

public static class Constants
{
    public static readonly JsonSerializerOptions SerializerSettings = new() { WriteIndented = true };
    public static readonly string SettingsPath = Path.Combine(CurrentDirectory, "Settings.json");
    private static string ExecutingAssemblyPathName => Environment.ProcessPath!;
    private static string CurrentDirectory => Path.GetDirectoryName(ExecutingAssemblyPathName)!;
    public static CrmSettings Settings => JsonSerializer.Deserialize<CrmSettings>(File.ReadAllText(SettingsPath))!;
}