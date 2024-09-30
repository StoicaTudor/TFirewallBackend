using TFirewall.Source.FirewallCore.Settings;

namespace TFirewall.Source.FirewallCore.Inspections;

public interface IInspection<in TSettings> where TSettings : InspectionSettings
{
    bool InspectionIsCompliant(HttpContext context, TSettings settings);
}