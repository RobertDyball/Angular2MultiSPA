using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2MultiSPA.Helpers
{
    public class CountryCultureInfo
    {

        // need to add helper methods to extract country/cultur einfofrom http context
        // perhaps: http://madskristensen.net/post/get-language-and-country-from-a-browser-in-aspnet
        // or https://weblog.west-wind.com/posts/2014/mar/27/auto-selecting-cultures-for-localization-in-aspnet
        // and https://docs.microsoft.com/en-us/aspnet/core/#localization-middleware

        //public static CultureInfo ResolveCulture()
        //{
        //    string[] languages = HttpContext.Current.Request.UserLanguages;

        //    if (languages == null || languages.Length == 0)
        //        return null;

        //    try
        //    {
        //        string language = languages[0].ToLowerInvariant().Trim();
        //        return CultureInfo.CreateSpecificCulture(language);
        //    }
        //    catch (ArgumentException)
        //    {
        //        return null;
        //    }
        //}
        //public static RegionInfo ResolveCountry()
        //{
        //    CultureInfo culture = ResolveCulture();
        //    if (culture != null)
        //        return new RegionInfo(culture.LCID);

        //    return null;
        //}
    }
}
