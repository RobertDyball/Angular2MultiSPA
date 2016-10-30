using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

namespace Angular2MultiSPA.Helpers
{
    /// <summary>
    /// Simple tag helper that creates a label and textbox combination in easier to read HTML than the full bootstrap form-group format.
    /// </summary>
    [HtmlTargetElement("form-entry")]
    public class FormEntryTagHelper : TagHelper
    {
        ///// <summary>
        ///// the main message that gets displayed
        ///// </summary>
        //[HtmlAttributeName("label-text")]
        //public string LabelText { get; set; }

        ///// <summary>
        ///// Optional header that is displayed in big text. Use for 'noisy' warnings and stop errors only please :-)
        ///// The message is displayed below the header.
        ///// </summary>
        //[HtmlAttributeName("value")]
        //public string Value { get; set; }

        ///// <summary>
        ///// Placeholder text
        ///// </summary>
        //[HtmlAttributeName("placeholder")]
        //public string PlaceHolder { get; set; }

        /// <summary>
        /// CSS class. Handled here so we can capture the existing
        /// class value and append the BootStrap alert class.
        /// </summary>
        [HtmlAttributeName("textbox-class")]
        public string TextBoxClass { get; set; } = "form-control";

        /// <summary>
        /// ViewModel name
        /// </summary>
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        //[HtmlAttributeName("id")]
        //public string Id { get; set; }

        //[HtmlAttributeName("type")]
        //public string Type { get; set; } = "text";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string textClass = "form-control"; //TextBoxClass;
            var propertyName = For.Name.Camelize();
            var labelName = ((DefaultModelMetadata)For.Metadata).DisplayName ?? For.Name.Humanize();
            var dataType = ((DefaultModelMetadata)For.Metadata).DataTypeName == "Password" ? "Password" : "Text";

            output.TagName = "div";
            output.Attributes.Add("class", "form-group");

            var label = new TagBuilder("label");
            label.MergeAttribute("for", propertyName);
            label.InnerHtml.AppendHtml(labelName);
            output.Content.SetHtmlContent(label);

            var input = new TagBuilder("input");
            input.MergeAttribute("id", propertyName);
            input.MergeAttribute("type", dataType);
            if (!string.IsNullOrEmpty(textClass)) input.AddCssClass(textClass);

            input.Attributes.Add("dummyvalue", "dummyvalue");
            input.Attributes.Add("placeholder", labelName);

            input.TagRenderMode = TagRenderMode.StartTag;

            output.PostContent.SetHtmlContent(input);

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"dummyvalue=""dummyvalue""", "#" + propertyName));

            // Debug.WriteLine(output.ToString());
        }
    }
}