using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

namespace Angular2MultiSPA.Helpers
{
    /// <summary>
    /// Tag helper to create form input tag and label combinations, styled using bootstrap form-group format.
    /// </summary>
    [HtmlTargetElement("tag-in")]
    public class TagInTagHelper : TagHelper
    {
        /// <summary>
        /// CSS class. Handled here so we can capture the existing class value and append the BootStrap alert class.
        /// </summary>
        [HtmlAttributeName("textbox-class")]
        public string TextBoxClass { get; set; } = "form-control";

        /// <summary>
        /// Hidden attribute
        /// </summary>
        [HtmlAttributeName("hidden")]
        public string Hidden { get; set; } = null;

        /// <summary>
        /// Hidden attribute
        /// </summary>
        [HtmlAttributeName("readonly")]
        public string Readonly { get; set; } = null;


        /// <summary>
        /// Alternate name to set angular data-binding to
        /// </summary>
        [HtmlAttributeName("bind-to")]
        public string BindTo { get; set; } = null;

        /// <summary>
        /// Alternate name to set angular parent data-binding to
        /// </summary>
        [HtmlAttributeName("bind-pa")]
        public string BindPa { get; set; } = null;
        /// <summary>
        /// ViewModel name
        /// </summary>
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var propertyName = For.Name.Camelize();
            var dataBindTo = propertyName.GetDataBindVariableName(BindPa, BindTo);

            string textClass = "form-control"; //TextBoxClass;
            var labelName = ((DefaultModelMetadata)For.Metadata).Placeholder ?? ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();
            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName;

            output.TagName = "div";
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.MergeAttribute("for", dataBindTo);
            label.InnerHtml.AppendHtml(labelName);
            output.PostContent.SetHtmlContent(label);

            var input = new TagBuilder("input");
            input.MergeAttribute("id", dataBindTo);
            if (!string.IsNullOrEmpty(textClass))
            {
                input.AddCssClass(textClass);
            }

            if (!string.IsNullOrEmpty(Hidden))
            {
                output.Attributes.Add("hidden", "hidden");
                input.Attributes.Add("hidden", "hidden");
            }

            if (!string.IsNullOrEmpty(Readonly) || For.Metadata.IsReadOnly)
            {
                input.Attributes.Add("readonly", "readonly");
            }

            input.Attributes.Add("#"+dataBindTo, "dummyvalue");
            // input.Attributes.Add("[(ngModel)]", dataBindTo);
            input.Attributes.Add("name", dataBindTo.Replace(".", string.Empty));
            input.Attributes.Add("id", dataBindTo.Replace(".", string.Empty));

            if (((DefaultModelMetadata)For.Metadata).HasMinLengthValidation())
            {
                input.Attributes.Add("minLength", ((DefaultModelMetadata)For.Metadata).MinLength().ToString());
            }

            if (((DefaultModelMetadata)For.Metadata).HasMaxLengthValidation())
            {
                input.Attributes.Add("maxLength", ((DefaultModelMetadata)For.Metadata).MaxLength().ToString());
            }

            if (((DefaultModelMetadata)For.Metadata).IsRequired)
            {
                input.Attributes.Add("required", "required");
            }

            if (For.Metadata.HasRegexValidation())
            {
                input.Attributes.Add("pattern", For.Metadata.RegexExpression());
            }

            input.Attributes.Add("placeholder", labelName);
            input.TagRenderMode = TagRenderMode.StartTag;

            // HTML5 input type="" to be supported
            //color
            //  date
            //  datetime
            //datetime-local
            //  email
            //month
            //  number
            //range
            //search
            //  tel
            //  time
            //  url
            //week

            switch (dataType)
            {
                case "Custom":
                    // TODO:    Represents a custom data type.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "DateTime":
                    // TODO:    Represents an instant in time, expressed as a date and time of day.
                    input.MergeAttribute("type", "datetime");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Date":
                    // TODO:    Represents a date value.
                    input.MergeAttribute("type", "date");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Time":
                    // TODO:    Represents a time value.
                    input.MergeAttribute("type", "time");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Duration":
                    // TODO:    Represents a continuous time during which an object exists.
                    input.MergeAttribute("type", "Text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "PhoneNumber":
                    //     Represents a phone number value.
                    input.MergeAttribute("type", "tel");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Currency":
                    //     Represents a currency value.
                    input.MergeAttribute("type", "number");

                    // add: <div class="input-group">
                    var divInputGroup = new TagBuilder("div");
                    divInputGroup.MergeAttribute("class", "input-group");

                    // add: <span class="input-group-addon">$</span>
                    var spanInputGroupAddon = new TagBuilder("span");
                    spanInputGroupAddon.MergeAttribute("class", "input-group-addon");
                    spanInputGroupAddon.InnerHtml.Append("$");
                    divInputGroup.InnerHtml.AppendHtml(spanInputGroupAddon);
                    divInputGroup.InnerHtml.AppendHtml(input);

                    output.PostContent.SetHtmlContent(divInputGroup);
                    break;

                case "Text":
                    //     Represents text that is displayed.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Html":
                    // TODO:    Represents an HTML file.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "MultilineText":
                    // TODO:    Represents multi-line text.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "EmailAddress":
                    //     Represents an e-mail address.
                    input.MergeAttribute("type", "email");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Password":
                    //     Represent a password value.
                    input.MergeAttribute("type", "password");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Url":
                    //     Represents a URL value.
                    input.MergeAttribute("type", "url");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "ImageUrl":
                    // TODO:    Represents a URL to an image.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "CreditCard":
                    // TODO:    Represents a credit card number.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "PostalCode":
                    // TODO:    Represents a postal code.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Upload":
                    // TODO:    Represents file upload data type.
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "System.String":
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "System.Int16":
                case "System.Int32":
                    input.MergeAttribute("type", "number");
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "System.Boolean":
                    // TODO: implement boolean data entry
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;

                default:
                    input.MergeAttribute("type", "text");
                    output.PostContent.SetHtmlContent(input);
                    break;
            }

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"=""dummyvalue""", string.Empty));
        }
    }
}

