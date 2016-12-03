using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

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
        /// Option: use HTML disabled attribute, alters how boolean values should be rendered on page;
        /// </summary>
        ///<remarks>Using this sets the HTML Disabled attribute but may result in rendering an HTML control that is too grey to be distinguished.
        /// This is as option, defaults is set to off.</remarks>
        [HtmlAttributeName("disabled")]
        public string Disabled { get; set; } = null;

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
            var dataBindTo = propertyName.GetDataBindVariableName(BindPa, BindTo);

            var labelName = ((DefaultModelMetadata)For.Metadata).Placeholder ?? ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();

            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName
                            ?? ((DefaultModelMetadata)For.Metadata).UnderlyingOrModelType.ToString();
            var isNullable = ((DefaultModelMetadata)For.Metadata).ModelType.ToString().Contains("System.Nullable");

            // HTML5 input type="" to be supported
            //color
            //date
            //datetime
            //datetime-local
            //email
            //month
            //number
            //range
            //search
            //tel
            //time
            //url
            //week


            output.TagName = "div";

            var input = new TagBuilder("span");

            switch (dataType)
            {
                case "Custom":
                    //     Represents a custom data type.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    // TODO: remove or set in compiler directive, for debugging
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "DateTime":
                    //     Represents an instant in time, expressed as a date and time of day.
                    // TODO: add smarter handling of formats; choices: localize to server, browser, or attributes/config
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'MM/dd/yyyy hh:mm:ss'}}");
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'dd/MM/yyyy hh:mm:ss'}}");
                    break;

                case "Date":
                    //     Represents a date value.
                    // TODO: add smarter handling of formats; choices: localize to server, browser, or attributes/config
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'MM/dd/yyyy'}}");
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'dd/MM/yyyy'}}");
                    break;

                case "Time":
                    //     Represents a time value.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'hh:mm:ss'}}");
                    break;

                case "Duration":
                    //     Represents a continuous time during which an object exists.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    // TODO: remove or set in compiler directive, for debugging
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "PhoneNumber":
                    //     Represents a phone number value.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "Currency":
                    //     Represents a currency value.
                    // TODO: add smarter handling of formats; choices: localize to server, browser, or attributes/config
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | currency:'AUD':true:'1.2-2'}}");
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | currency:'USD':true:'1.2-2'}}");
                    break;

                case "Text":
                    //     Represents text that is displayed.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "Html":
                    //     Represents an HTML file.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "MultilineText":
                    //     Represents multi-line text.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "EmailAddress":
                    //     Represents an e-mail address.
                    //     Represents a URL value.
                    var e = new TagBuilder("a");
                    e.TagRenderMode = TagRenderMode.StartTag;
                    e.Attributes.Add("id", propertyName);
                    e.Attributes.Add("mailto", "{{" + dataBindTo + "}}");
                    input.InnerHtml.AppendHtml(e);
                    break;

                case "Password":
                    //     Represent a password value.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "Url":
                    //     Represents a URL value.
                    var u = new TagBuilder("a");
                    u.TagRenderMode = TagRenderMode.StartTag;
                    u.Attributes.Add("id", propertyName);
                    u.Attributes.Add("href", "{{" + dataBindTo + "}}");
                    input.InnerHtml.AppendHtml(u);
                    break;

                case "ImageUrl":
                    //     Represents a URL to an image.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "CreditCard":
                    //     Represents a credit card number.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "PostalCode":
                    //     Represents a postal code.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "Upload":
                    //     Represents file upload data type.
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;

                case "System.String":
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    break;

                case "System.Int16":
                case "System.Int32":
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
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
                    // TODO: remove or set in compiler directive, for debugging
                    input.Attributes.Add("title", string.Format("object name: {0}", dataBindTo));
                    //input.Attributes.Add("title", string.Format("render bool as: {0}", RendBool));
                    break;

                default:
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
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
