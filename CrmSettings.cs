namespace crm_gui;

public sealed record CrmSettings
{
    public string? CrmUrl { get; set; }
    public string? CrmClientId { get; set; }
    public string? CrmClientSecret { get; set; }
}