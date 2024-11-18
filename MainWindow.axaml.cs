using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace crm_gui;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var registryOptions = new RegistryOptions(ThemeName.DarkPlus);
        var textMateInstallation = TBQ1.InstallTextMate(registryOptions);
        var xmlLang = registryOptions.GetLanguageByExtension(".xml");
        textMateInstallation.SetGrammar(registryOptions.GetScopeByLanguageId(xmlLang.Id));

        var textMateInstallation1 = TB1.InstallTextMate(registryOptions);
        var jsonLang = registryOptions.GetLanguageByExtension(".json");
        textMateInstallation1.SetGrammar(registryOptions.GetScopeByLanguageId(jsonLang.Id));

        InitializeSettings();
    }

    private void InitializeSettings()
    {
        CrmUrl.Text = Constants.Settings.CrmUrl;
        CrmClientId.Text = Constants.Settings.CrmClientId;
        CrmClientSecret.Text = Constants.Settings.CrmClientSecret;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        TB1.Text = CRM.GetDataFromCRM(TBQ1.Text ?? string.Empty);
    }

    private void SaveSettingsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var data = JsonSerializer.Serialize(new CrmSettings
        {
            CrmUrl = CrmUrl.Text,
            CrmClientId = CrmClientId.Text,
            CrmClientSecret = CrmClientSecret.Text
        }, Constants.SerializerSettings);

        File.WriteAllText(Constants.SettingsPath, data);
    }
}