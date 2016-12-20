using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace Angular2MultiSPA.Helpers
{
    /// <summary>
    /// Tag helper for displaying data. This tag helper creates a span tag containing formatted data according to the supplied view model property.
    /// </summary>
    [HtmlTargetElement("tag-da")]
    public class TagDaTagHelper : TagHelper
    {
        /// <summary>
        /// Alternate name to set angular data-binding to (overrides default name based on property name)
        /// </summary>
        [HtmlAttributeName("bind-to")]
        public string BindTo { get; set; } = null;

        /// <summary>
        /// Alternate name to set angular parent data-binding to (default, none)
        /// </summary>
        /// <remarks>
        /// the string entered here will be used to prefix the property name, 
        /// eg., if the 'bind-to' property is called, say, "phoneNumber" and this "bind-pa" attribute has the value "employee" 
        /// then the angular data binding will be set to "employee.phoneNumber"
        /// </remarks>
        [HtmlAttributeName("bind-pa")]
        public string BindPa { get; set; } = null;

        /// <summary>
        /// Option: sets display formats for common data types using Angular 2 pipes; can be used for date, time, date/time, number and currency values
        /// </summary>
        ///<remarks>If not specified, a default pipe format will created based on (supported) data type and on Angular 2 and browser defaults.
        /// To prevent this default format, use: format="none"
        /// Note that the pipe format should be surrounded within single quotes; further options are:
        /// 'server' = set pipe format 'xxx' using server defaults for that data type, or
        /// 'code' = set pipe format 'xxx' using the DisplayFormat attribute on data entity in server side code, if none specified, reverts to server default
        /// 'xxx' = set format to a specific pipe format 'xxx'. 
        /// For percentages or more direct access to pipe and pipe options <seealso cref="Pipe"/> </remarks>
        /// <example>
        /// Valid date, time and date/time formats are:
        /// 'medium': equivalent to 'yMMMdjms' (e.g. Sep 3, 2010, 12:05:08 PM for en-US)
        /// 'short': equivalent to 'yMdjm' (e.g. 9/3/2010, 12:05 PM for en-US)
        /// 'fullDate': equivalent to 'yMMMMEEEEd' (e.g.Friday, September 3, 2010 for en-US)
        /// 'longDate': equivalent to 'yMMMMd' (e.g.September 3, 2010 for en-US)
        /// 'mediumDate': equivalent to 'yMMMd' (e.g.Sep 3, 2010 for en-US)
        /// 'shortDate': equivalent to 'yMd' (e.g. 9/3/2010 for en-US)
        /// 'mediumTime': equivalent to 'jms' (e.g. 12:05:08 PM for en-US)
        /// 'shortTime': equivalent to 'jm' (e.g. 12:05 PM for en-US)
        /// </example>
        [HtmlAttributeName("format")]
        public string Format { get; set; } = null;

        /// <summary>
        /// Option: directly set display format using Angular 2 pipe and pipe format values
        /// </summary>
        ///<remarks>This attribute sets both pipe type and the pipe filter parameters.
        /// For simple formatting of common data types <seealso cref="Format"/>.
        /// Numeric formats for decimal or percent in Angular use a string with the following format: 
        /// a.b-c where:
        ///     a = minIntegerDigits is the minimum number of integer digits to use.Defaults to 1.
        ///     b = minFractionDigits is the minimum number of digits after fraction.Defaults to 0.
        ///     c = maxFractionDigits is the maximum number of digits after fraction.Defaults to 3.
        /// </remarks>
        /// <example>
        /// to format a decimal value as a percentage use "|percent" for the default Angular
        /// or for a custom percentage value eg. "| percent:'1:3-5' 
        /// </example>
        [HtmlAttributeName("pipe")]
        public string Pipe { get; set; } = null;

        /// <summary>
        /// Option: use HTML disabled attribute, alters how boolean values should be rendered on page;
        /// </summary>
        ///<remarks>Using this sets the HTML Disabled attribute but may result in rendering an HTML control that is too grey to be distinguished.
        /// This is as option, default is off.</remarks>
        [HtmlAttributeName("disabled")]
        public string Disabled { get; set; } = null;

        /// <summary>
        /// Option: use show password icon, provide users a way to see password optionally;
        /// </summary>
        ///<remarks>This is as option, default is off.</remarks>
        [HtmlAttributeName("show")]
        public string Show { get; set; } = null;

        /// <summary>
        /// Option: how boolean values should be rendered
        /// </summary>
        /// <remarks>Choices: cb = checkbox, yn = yes/no, tf = true/false(default)</remarks>
        [HtmlAttributeName("rend-bool")]
        public BooleanDisplayOptions RendBool { get; set; } = BooleanDisplayOptions.tf;

        /// <summary>
        /// ViewModel name
        /// </summary>
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var propertyName = For.Name.Camelize();
            var idName = propertyName.Replace(".", string.Empty);
            var dataBindTo = propertyName.GetDataBindVariableName(BindPa, BindTo);

            var labelName = ((DefaultModelMetadata)For.Metadata).Placeholder ?? ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();

            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName
                            ?? ((DefaultModelMetadata)For.Metadata).UnderlyingOrModelType.ToString();
            var isNullable = ((DefaultModelMetadata)For.Metadata).ModelType.ToString().Contains("System.Nullable");

            output.TagName = "div";
            var pipe = string.IsNullOrEmpty(Pipe) ? string.Empty : Pipe;
            var input = new TagBuilder("span");

            switch (dataType)
            {
                case "Custom":
                    // Represents a custom data type. NOTE: not yet implemented
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    break;

                case "DateTime":
                    // Represents an instant in time, expressed as a date and time of day.
                    var datetimeFormat = Format.GetFormat(dataType);
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + datetimeFormat + pipe + "}}");
                    break;

                case "Date":
                    // Represents a date value.
                    // see: https://angular.io/docs/ts/latest/api/common/index/DatePipe-pipe.html
                    var dateFormat = Format.GetFormat(dataType);
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + dateFormat + pipe + "}}");
                    break;

                case "Time":
                    // Represents a time value.
                    // see: https://angular.io/docs/ts/latest/api/common/index/DatePipe-pipe.html
                    var timeFormat = Format.GetFormat(dataType);
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + timeFormat + pipe + "}}");
                    break;

                case "Duration":
                    // Represents a continuous time during which an object exists.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    break;

                case "PhoneNumber":
                    // Represents a phone number value.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "Currency":
                    // Represents a currency value.
                    var currencyFormat = Format.GetFormat(dataType);
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + currencyFormat + pipe + "}}");
                    break;

                case "Text":
                    // Represents text that is displayed.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    break;

                case "Html":
                    // Represents an HTML file.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "MultilineText":
                    // Represents multi-line text.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "EmailAddress":
                    // Represents an e-mail address.
                    // Represents a URL value.
                    var e = new TagBuilder("a");
                    e.TagRenderMode = TagRenderMode.StartTag;
                    e.Attributes.Add("id", idName);
                    e.Attributes.Add("name", idName);
                    e.Attributes.Add("href", "mailto:{{" + dataBindTo + "}}");
                    input.InnerHtml.AppendHtml(e);
                    break;

                case "Password":
                    // Represent a password value.
                    input.InnerHtml.AppendHtml("********");
                    break;

                case "Url":
                    // Represents a URL value.
                    var u = new TagBuilder("a");
                    u.TagRenderMode = TagRenderMode.StartTag;
                    u.Attributes.Add("id", idName);
                    u.Attributes.Add("name", idName);
                    u.Attributes.Add("href", "{{" + dataBindTo + "}}");
                    input.InnerHtml.AppendHtml(u);
                    break;

                case "ImageUrl":
                    // Represents a URL to an image.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "CreditCard":
                    // Represents a credit card number.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "PostalCode":
                    // Represents a postal code.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "Upload":
                    // Represents file upload data type.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "System.Int16":
                case "System.Int32":
                case "System.String":
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    break;

                case "System.Decimal":
                case "decimal":
                    var numberFormat = Format.GetFormat(dataType);
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + numberFormat + pipe + "}}");
                    break;

                case "System.Boolean":
                    switch (RendBool)
                    {
                        case BooleanDisplayOptions.cb:
                            var cb = new TagBuilder("input");
                            cb.TagRenderMode = TagRenderMode.StartTag;
                            cb.Attributes.Add("type", "checkbox");
                            cb.Attributes.Add("id", propertyName);
                            cb.Attributes.Add("readonly", "true");
                            cb.Attributes.Add("onclick", "return false");

                            if (Disabled != null && "True true Disabled disabled".Contains(Disabled))
                            {
                                cb.Attributes.Add("disabled", "true");
                            }

                            cb.Attributes.Add("[(ngModel)]", dataBindTo);

                            input.InnerHtml.AppendHtml(cb);
                            break;

                        case BooleanDisplayOptions.yn:
                            input.InnerHtml.AppendHtml("{{" + dataBindTo + " ? 'Yes' : 'No'}}");
                            break;

                        case BooleanDisplayOptions.tf:
                        default:
                            input.InnerHtml.AppendHtml("{{" + dataBindTo + " }}");
                            break;
                    }

                    input.Attributes.Add("title", string.Format("object name: {0}", dataBindTo));
                    break;

                default:
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + pipe + "}}");
                    // TODO: remove or set in compiler directive, for debugging
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;
            }

            input.TagRenderMode = TagRenderMode.Normal;
            output.PostContent.SetHtmlContent(input);

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"=""dummyvalue""", string.Empty));
        }

    }
}
