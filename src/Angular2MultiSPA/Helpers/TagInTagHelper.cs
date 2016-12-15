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
        /// Row count attribute (for textarea)
        /// </summary>
        [HtmlAttributeName("rows")]
        public int? Rows { get; set; } = null;


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
            var labelName = ((DefaultModelMetadata)For.Metadata).Placeholder ?? ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();
            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName;

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
            //*tel
            //*time
            //*url
            //week

            output.TagName = "div";
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.MergeAttribute("for", dataBindTo);
            label.InnerHtml.AppendHtml(labelName);
            output.PostContent.SetHtmlContent(label);

            TagBuilder input = null;

            switch (dataType)
            {
                case "Custom":
                case "DateTime":
                case "Date":
                case "Time":
                case "Duration":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", dataType);
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "PhoneNumber":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "tel");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "Currency":
                case "Text":
                case "Html":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", dataType);
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "MultilineText":
                    input = new TagBuilder("textarea");
                    if (Rows != null)
                    {
                        input.Attributes.Add("rows", Rows.Value.ToString());
                    }
                    input.TagRenderMode = TagRenderMode.Normal;
                    break;

                case "EmailAddress":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "email");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "Url":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "url");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "Password":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "password");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                case "ImageUrl":
                case "CreditCard":
                case "PostalCode":
                case "Upload":
                case "System.String":
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "text");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;

                default:
                    input = new TagBuilder("input");
                    input.MergeAttribute("type", "text");
                    input.TagRenderMode = TagRenderMode.StartTag;
                    break;
            }



            input.MergeAttribute("id", dataBindTo);
            input.AddCssClass(TextBoxClass);

            if (!string.IsNullOrEmpty(Hidden))
            {
                output.Attributes.Add("hidden", "hidden");
                input.Attributes.Add("hidden", "hidden");
            }

            if (!string.IsNullOrEmpty(Readonly) || For.Metadata.IsReadOnly)
            {
                input.Attributes.Add("readonly", "readonly");
            }

            input.Attributes.Add("#" + dataBindTo, "dummyvalue");

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

            switch (dataType)
            {
                case "Custom":
                case "DateTime":
                case "Date":
                case "Time":
                case "Duration":
                case "PhoneNumber":
                    output.PostContent.SetHtmlContent(input);
                    break;

                case "Currency":
                    // <div class="input-group">
                    var divInputGroup = new TagBuilder("div");
                    divInputGroup.MergeAttribute("class", "input-group");

                    // <span class="input-group-addon">$</span>
                    var spanInputGroupAddon = new TagBuilder("span");
                    spanInputGroupAddon.MergeAttribute("class", "input-group-addon");
                    spanInputGroupAddon.InnerHtml.Append("$");
                    divInputGroup.InnerHtml.AppendHtml(spanInputGroupAddon);
                    divInputGroup.InnerHtml.AppendHtml(input);

                    output.PostContent.SetHtmlContent(divInputGroup);
                    break;

                case "Text":
                case "Html":
                case "MultilineText":
                case "EmailAddress":
                case "Url":
                case "Password":
                case "ImageUrl":
                case "CreditCard":
                case "PostalCode":
                case "Upload":
                case "System.String":
                    output.PostContent.SetHtmlContent(input);
                    break;

                default:
                    output.PostContent.SetHtmlContent(input);
                    break;
            }

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"=""dummyvalue""", string.Empty));
        }
    }
}

