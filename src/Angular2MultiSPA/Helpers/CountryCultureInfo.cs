using System;
using System.Diagnostics;

namespace Angular2MultiSPA.Helpers
{
    public static class CountryCultureInfo
    {
        public static string GetFormat(this string format, string dataType)
        {
            string pipeFormat = null;
            string pipeFilter = null;

            // to have the data display as-is with no special formatting, use attribute: format="none" 
            if (format != null && (format.ToLower() == "none" || format.ToLower() == "'none'"))
            {
                return string.Empty;
            }

            // dddd, d MMMM yyyy
            Debug.WriteLine(System.Globalization.DateTimeFormatInfo.CurrentInfo.LongDatePattern.ToString());

            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalDigits.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSizes.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalDigits.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.NumberNegativePattern.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyPositivePattern.ToString());
            Debug.WriteLine(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyNegativePattern.ToString());

            //Debug.WriteLine("The DateTime Format is {0}", CultureInfo.CurrentCulture.DateTimeFormat);
            //Debug.WriteLine("The Number Format is {0}", CultureInfo.CurrentCulture.NumberFormat);
            //Debug.WriteLine("The DisplayName is {0}", CultureInfo.CurrentCulture.DisplayName);
            //Debug.WriteLine("The TwoLetterISOLanguageName is {0}", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);




            // TODO: add smarter handling of formats; choices: localize to server, browser, or attributes/config
            switch (dataType)
            {
                case "DateTime":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/DatePipe-pipe.html
                    pipeFilter = "date";
                    pipeFormat = (format == "server") ?
                                    System.Globalization.DateTimeFormatInfo.CurrentInfo.FullDateTimePattern.DateTimeFormatInfoToAngular()
                                    : (string.IsNullOrEmpty(format)) ? 
                                            "'yyyy/MM/dd hh:mm:ss'" 
                                            : string.Format("{0}", format);
                    break;

                case "Date":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/DatePipe-pipe.html
                    pipeFilter = "date";
                    pipeFormat = (format == "server") ?
                                    System.Globalization.DateTimeFormatInfo.CurrentInfo.LongDatePattern.DateTimeFormatInfoToAngular()
                                    : (string.IsNullOrEmpty(format)) ?
                                            "'yyyy/MM/dd'"
                                            : string.Format("{0}", format);
                    break;

                case "Time":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/DatePipe-pipe.html
                    pipeFilter = "date";
                    pipeFormat = (format == "server") ?
                                    System.Globalization.DateTimeFormatInfo.CurrentInfo.LongTimePattern.DateTimeFormatInfoToAngular()
                                    : (string.IsNullOrEmpty(format)) ?
                                            "'HH:mm:ss'"
                                            : string.Format("{0}", format);
                    break;

                case "System.Int16":
                case "System.Int32":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/DecimalPipe-pipe.html
                    pipeFilter = "number";
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'1.0-0'" : string.Format("{0}", format);
                    break;

                case "System.Decimal":
                case "decimal":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/DecimalPipe-pipe.html
                    pipeFilter = "number";
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'1.0-3'" : string.Format("{0}", format);
                    break;

                case "Duration":
                    return string.Empty;

                case "Currency":
                    // Angular 2 format specs see: https://angular.io/docs/ts/latest/api/common/index/CurrencyPipe-pipe.html
                    pipeFilter = "currency";
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'USD':false:'1.2-2'" : string.Format("{0}", format);
                    break;

                default:
                    return string.Empty;
            }

            if (string.IsNullOrEmpty(pipeFormat))
            {
                if (string.IsNullOrEmpty(pipeFilter))
                {
                    return string.Empty;
                }

                return string.Format(" | {0} ", pipeFilter);
            }

            return string.Format(" | {0}:{1} ", pipeFilter, pipeFormat);
        }

        private static string DateTimeFormatInfoToAngular(this string dateTimeInfoPattern)
        {
            var format = dateTimeInfoPattern.Replace("dddd", "EEE")      // long day 'Sunday'
                        .Replace("ddd", "EEE")                           // abbreviated day 'Sun'
                        .Replace("tt", "a")                             // AM/PM
                        .Replace("GMT", "z")                            // time zone
                        .Replace(",", string.Empty)
                        .Replace("'", string.Empty);

            return string.Format("'{0}'", format);
        }

        // need to add helper methods to extract country/culture info from http context
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
