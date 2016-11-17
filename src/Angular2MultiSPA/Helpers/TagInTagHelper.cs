using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Text.RegularExpressions;

namespace Angular2MultiSPA.Helpers
{
    /// <summary>
    /// Simple tag helper that creates a label and textbox combination in easier to read HTML than the full bootstrap form-group format.
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
            string textClass = "form-control"; //TextBoxClass;
            var propertyName = For.Name.Camelize();
            var labelName = ((DefaultModelMetadata)For.Metadata).Placeholder ?? ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();
            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName;
            var inputType = dataType == "Password" ? "Password" : "Text";

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
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.MergeAttribute("for", propertyName);
            label.InnerHtml.AppendHtml(labelName);
            output.PostContent.SetHtmlContent(label);

            var input = new TagBuilder("input");
            input.MergeAttribute("id", propertyName);
            input.MergeAttribute("type", dataType);
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

            input.Attributes.Add("#" + propertyName, "dummyvalue");

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

            if (dataType == "Currency")
            {
                //<div class="input-group">
                var divInputGroup = new TagBuilder("div");
                divInputGroup.MergeAttribute("class", "input-group");

                // <span class="input-group-addon">$</span>
                var spanInputGroupAddon = new TagBuilder("span");
                spanInputGroupAddon.MergeAttribute("class", "input-group-addon");
                spanInputGroupAddon.InnerHtml.Append("$");
                divInputGroup.InnerHtml.AppendHtml(spanInputGroupAddon);
                divInputGroup.InnerHtml.AppendHtml(input);

                output.PostContent.SetHtmlContent(divInputGroup);
            }
            else
            {
                output.PostContent.SetHtmlContent(input);
            }

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"=""dummyvalue""", string.Empty));
        }
    }
}

