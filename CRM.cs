// ReSharper disable InconsistentNaming

using System;
using System.Text.Json;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Query;

namespace crm_gui;

public static class CRM
{
    // This service connection string uses the info provided above.
    // The AppId and RedirectUri are provided for sample code testing.
    private static readonly string CONNECTIONSTRING =
        $"AuthType=ClientSecret;Url={Constants.Settings.CrmUrl};ClientId={Constants.Settings.CrmClientId};ClientSecret={Constants.Settings.CrmClientSecret};";

    private static readonly ServiceClient _service = new(CONNECTIONSTRING);

    public static string GetDataFromCRM(string query)
    {
        try
        {
            var fetchExpression = new FetchExpression(query);
            var entityCollection = _service.RetrieveMultiple(fetchExpression);
            var data = JsonSerializer.Serialize(entityCollection, Constants.SerializerSettings);

            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return string.Empty;
    }
}