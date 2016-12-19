namespace Angular2MultiSPA.Helpers
{
    public static class CountryCultureInfo
    {
        public static string GetFormat(this string format, string dataType)
        {
            string pipeFormat = null;
            string pipeFilter = null;

            // to have the data display as-is with no special formatting, use attribute: format="none" 
            if (format != null && format.ToLower() == "none")
            {
                return string.Empty;
            }

            // TODO: add smarter handling of formats; choices: localize to server, browser, or attributes/config
            switch (dataType)
            {
                case "DateTime":
                    pipeFilter = "date";
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'MM/dd/yyyy hh:mm:ss'}}");
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'yyyy/MM/dd hh:mm:ss'" : string.Format("{0}", format);
                    break;

                case "Date":
                    pipeFilter = "date";
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'MM/dd/yyyy'}}");
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'yyyy/MM/dd'" : string.Format("{0}", format);
                    break;

                case "Time":
                    pipeFilter = "date";
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'HH:mm:ss'" : string.Format("{0}", format);
                    break;

                case "Duration":
                    return string.Empty;

                case "Currency":
                    pipeFilter = "currency";
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | currency:'AUD':true:'1.2-2'}}");
                    pipeFormat = (string.IsNullOrEmpty(format)) ? "'USD':true:'1.2-2'" : string.Format("{0}", format);
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
