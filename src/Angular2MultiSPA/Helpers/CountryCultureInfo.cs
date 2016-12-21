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
                    // NOTE: if required add your own ISO 4217 lookup here, 
                    // to translate from System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol etc.
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

        /// <summary>
        /// Translates ASP.Net Core date time info format codes into Angular 2 format codes
        /// </summary>
        /// <param name="dateTimeInfoPattern">ASPNet.core date time format string</param>
        /// <returns>Angular 2 date time format string</returns>
        /// <remarks>
        /// ASP.Net Core represents weekday as "ddd" (Sun) or "dddd" (Sunday) whereas Angular uses "EEE" (Sun) or "EEEE" (Sunday)
        /// Use this method to translate, or adjust defaults as needed
        /// </remarks>
        private static string DateTimeFormatInfoToAngular(this string dateTimeInfoPattern)
        {
            var format = dateTimeInfoPattern.Replace("dddd", "EEE")
                        .Replace("ddd", "EEE")
                        .Replace("tt", "a")
                        .Replace("GMT", "z")
                        .Replace(",", string.Empty)
                        .Replace("'", string.Empty);

            return string.Format("'{0}'", format);
        }
    }
}
