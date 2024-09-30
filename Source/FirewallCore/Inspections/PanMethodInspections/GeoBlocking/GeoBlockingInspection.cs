using TFirewall.Source.FirewallCore.Settings;
using TFirewall.Source.Util.Countries;
using TFirewall.Source.Util.ExtensionMethods;

namespace TFirewall.Source.FirewallCore.Inspections.PanMethodInspections.GeoBlocking;

public class GeoBlockingInspection : IInspection<GeoBlockingInspectionSettings>
{
    public bool InspectionIsCompliant(HttpContext context, GeoBlockingInspectionSettings settings) =>
        RequestDoesOriginateFromAllowedCountries(context, settings)
        && RequestDoesNotOriginateFromForbiddenCountries(context, settings);

    private static readonly Random Random = new();
    private static bool RequestDoesOriginateFromAllowedCountries(
        HttpContext context,
        GeoBlockingInspectionSettings settings
    ) => settings.AllowedCountriesCodes.Contains(GetUserCountryByIp("mock"));

    private static bool RequestDoesNotOriginateFromForbiddenCountries(
        HttpContext context,
        GeoBlockingInspectionSettings settings
    ) => settings.ForbiddenCountriesCodes.DoesNotContain(GetUserCountryByIp("mock"));

    private static string GetUserCountryByIp(string ip) =>
        Random.Next(1, 101).IsEven() ? CountryCodes.GetRandomCountryCode() : "CN";
}