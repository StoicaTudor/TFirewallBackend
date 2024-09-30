﻿namespace TFirewall.Source.Util.Countries;

public static class CountryCodes
{
    private static readonly Random Random = new();
    private static readonly int NrOfCountries = Enum.GetValues(typeof(Countries)).Length;

    public static readonly Dictionary<Countries, string> CountriesCodes = new()
    {
        { Countries.Afghanistan, "AF" },
        { Countries.Albania, "AL" },
        { Countries.Algeria, "DZ" },
        { Countries.Andorra, "AD" },
        { Countries.Angola, "AO" },
        { Countries.Argentina, "AR" },
        { Countries.Armenia, "AM" },
        { Countries.Australia, "AU" },
        { Countries.Austria, "AT" },
        { Countries.Azerbaijan, "AZ" },
        { Countries.Bahamas, "BS" },
        { Countries.Bahrain, "BH" },
        { Countries.Bangladesh, "BD" },
        { Countries.Barbados, "BB" },
        { Countries.Belarus, "BY" },
        { Countries.Belgium, "BE" },
        { Countries.Belize, "BZ" },
        { Countries.Benin, "BJ" },
        { Countries.Bhutan, "BT" },
        { Countries.Bolivia, "BO" },
        { Countries.BosniaAndHerzegovina, "BA" },
        { Countries.Botswana, "BW" },
        { Countries.Brazil, "BR" },
        { Countries.Brunei, "BN" },
        { Countries.Bulgaria, "BG" },
        { Countries.BurkinaFaso, "BF" },
        { Countries.Burundi, "BI" },
        { Countries.Cambodia, "KH" },
        { Countries.Cameroon, "CM" },
        { Countries.Canada, "CA" },
        { Countries.CapeVerde, "CV" },
        { Countries.CentralAfricanRepublic, "CF" },
        { Countries.Chad, "TD" },
        { Countries.Chile, "CL" },
        { Countries.China, "CN" },
        { Countries.Colombia, "CO" },
        { Countries.Comoros, "KM" },
        { Countries.Congo, "CG" },
        { Countries.CostaRica, "CR" },
        { Countries.Croatia, "HR" },
        { Countries.Cuba, "CU" },
        { Countries.Cyprus, "CY" },
        { Countries.CzechRepublic, "CZ" },
        { Countries.Denmark, "DK" },
        { Countries.Djibouti, "DJ" },
        { Countries.Dominica, "DM" },
        { Countries.DominicanRepublic, "DO" },
        { Countries.EastTimor, "TL" },
        { Countries.Ecuador, "EC" },
        { Countries.Egypt, "EG" },
        { Countries.ElSalvador, "SV" },
        { Countries.EquatorialGuinea, "GQ" },
        { Countries.Eritrea, "ER" },
        { Countries.Estonia, "EE" },
        { Countries.Eswatini, "SZ" },
        { Countries.Ethiopia, "ET" },
        { Countries.Fiji, "FJ" },
        { Countries.Finland, "FI" },
        { Countries.France, "FR" },
        { Countries.Gabon, "GA" },
        { Countries.Gambia, "GM" },
        { Countries.Georgia, "GE" },
        { Countries.Germany, "DE" },
        { Countries.Ghana, "GH" },
        { Countries.Greece, "GR" },
        { Countries.Grenada, "GD" },
        { Countries.Guatemala, "GT" },
        { Countries.Guinea, "GN" },
        { Countries.GuineaBissau, "GW" },
        { Countries.Guyana, "GY" },
        { Countries.Haiti, "HT" },
        { Countries.Honduras, "HN" },
        { Countries.Hungary, "HU" },
        { Countries.Iceland, "IS" },
        { Countries.India, "IN" },
        { Countries.Indonesia, "ID" },
        { Countries.Iran, "IR" },
        { Countries.Iraq, "IQ" },
        { Countries.Ireland, "IE" },
        { Countries.Israel, "IL" },
        { Countries.Italy, "IT" },
        { Countries.IvoryCoast, "CI" },
        { Countries.Jamaica, "JM" },
        { Countries.Japan, "JP" },
        { Countries.Jordan, "JO" },
        { Countries.Kazakhstan, "KZ" },
        { Countries.Kenya, "KE" },
        { Countries.Kiribati, "KI" },
        { Countries.KoreaNorth, "KP" },
        { Countries.KoreaSouth, "KR" },
        { Countries.Kuwait, "KW" },
        { Countries.Kyrgyzstan, "KG" },
        { Countries.Laos, "LA" },
        { Countries.Latvia, "LV" },
        { Countries.Lebanon, "LB" },
        { Countries.Lesotho, "LS" },
        { Countries.Liberia, "LR" },
        { Countries.Libya, "LY" },
        { Countries.Liechtenstein, "LI" },
        { Countries.Lithuania, "LT" },
        { Countries.Luxembourg, "LU" },
        { Countries.Madagascar, "MG" },
        { Countries.Malawi, "MW" },
        { Countries.Malaysia, "MY" },
        { Countries.Maldives, "MV" },
        { Countries.Mali, "ML" },
        { Countries.Malta, "MT" },
        { Countries.MarshallIslands, "MH" },
        { Countries.Mauritania, "MR" },
        { Countries.Mauritius, "MU" },
        { Countries.Mexico, "MX" },
        { Countries.Micronesia, "FM" },
        { Countries.Moldova, "MD" },
        { Countries.Monaco, "MC" },
        { Countries.Mongolia, "MN" },
        { Countries.Montenegro, "ME" },
        { Countries.Morocco, "MA" },
        { Countries.Mozambique, "MZ" },
        { Countries.Myanmar, "MM" },
        { Countries.Namibia, "NA" },
        { Countries.Nauru, "NR" },
        { Countries.Nepal, "NP" },
        { Countries.Netherlands, "NL" },
        { Countries.NewZealand, "NZ" },
        { Countries.Nicaragua, "NI" },
        { Countries.Niger, "NE" },
        { Countries.Nigeria, "NG" },
        { Countries.Norway, "NO" },
        { Countries.Oman, "OM" },
        { Countries.Pakistan, "PK" },
        { Countries.Palau, "PW" },
        { Countries.Panama, "PA" },
        { Countries.PapuaNewGuinea, "PG" },
        { Countries.Paraguay, "PY" },
        { Countries.Peru, "PE" },
        { Countries.Philippines, "PH" },
        { Countries.Poland, "PL" },
        { Countries.Portugal, "PT" },
        { Countries.Qatar, "QA" },
        { Countries.Romania, "RO" },
        { Countries.Russia, "RU" },
        { Countries.Rwanda, "RW" },
        { Countries.SaintKittsAndNevis, "KN" },
        { Countries.SaintLucia, "LC" },
        { Countries.SaintVincentAndTheGrenadines, "VC" },
        { Countries.Samoa, "WS" },
        { Countries.SanMarino, "SM" },
        { Countries.SaoTomeAndPrincipe, "ST" },
        { Countries.SaudiArabia, "SA" },
        { Countries.Senegal, "SN" },
        { Countries.Serbia, "RS" },
        { Countries.Seychelles, "SC" },
        { Countries.SierraLeone, "SL" },
        { Countries.Singapore, "SG" },
        { Countries.Slovakia, "SK" },
        { Countries.Slovenia, "SI" },
        { Countries.SolomonIslands, "SB" },
        { Countries.Somalia, "SO" },
        { Countries.SouthAfrica, "ZA" },
        { Countries.Spain, "ES" },
        { Countries.SriLanka, "LK" },
        { Countries.Sudan, "SD" },
        { Countries.Suriname, "SR" },
        { Countries.Sweden, "SE" },
        { Countries.Switzerland, "CH" },
        { Countries.Syria, "SY" },
        { Countries.Taiwan, "TW" },
        { Countries.Tajikistan, "TJ" },
        { Countries.Tanzania, "TZ" },
        { Countries.Thailand, "TH" },
        { Countries.Togo, "TG" },
        { Countries.Tonga, "TO" },
        { Countries.TrinidadAndTobago, "TT" },
        { Countries.Tunisia, "TN" },
        { Countries.Turkey, "TR" },
        { Countries.Turkmenistan, "TM" },
        { Countries.Tuvalu, "TV" },
        { Countries.Uganda, "UG" },
        { Countries.Ukraine, "UA" },
        { Countries.UnitedArabEmirates, "AE" },
        { Countries.UnitedKingdom, "GB" },
        { Countries.UnitedStates, "US" },
        { Countries.Uruguay, "UY" },
        { Countries.Uzbekistan, "UZ" },
        { Countries.Vanuatu, "VU" },
        { Countries.VaticanCity, "VA" },
        { Countries.Venezuela, "VE" },
        { Countries.Vietnam, "VN" },
        { Countries.Yemen, "YE" },
        { Countries.Zambia, "ZM" },
        { Countries.Zimbabwe, "ZW" }
    };

    public static string GetRandomCountryCode() => CountriesCodes[(Countries)Random.Next(0, NrOfCountries)];
}