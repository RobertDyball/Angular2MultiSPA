using Humanizer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Angular2MultiSPA.Helpers
{
    /// <summary>
    /// Simple tag helper that creates span tag contining formatted data according to the supplied viewmodel property.
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
        [HtmlAttributeName("bind-pa")]
        public string BindPa { get; set; } = null;

        /// <summary>
        /// Option: use HTML disabled attribute, alters how boolean values should be rendered on page;
        /// </summary>
        ///<remarks>Since this may be too greyed out, this is as option</remarks>
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

            var dataBindTo = GetDataBindVariableName(BindPa, BindTo, propertyName);

            output.TagName = "div";

            var input = new TagBuilder("span");

            switch (dataType)
            {
                case "Currency":
                    // TODO: add smarter handling of formats; choices: localise to server, browser, or attributes/config
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | currency:'AUD':true:'1.2-2'}}");
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | currency:'USD':true:'1.2-2'}}");
                    break;

                case "Date":
                    // TODO: add smarter handling of formats; choices: localise to server, browser, or attributes/config
                    // input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'MM/dd/yyyy'}}");
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + " | date:'dd/MM/yyyy'}}");
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

                            // TODO need to fix checked/unchecked data binding
                            cb.Attributes.Add("[(ngModel)]", dataBindTo);
                            //cb.Attributes.Add("[(checked)]", dataBindTo);

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
                    // TODO: remove or set in compiler direcive, for debugging
                    input.Attributes.Add("title", string.Format("object name: {0}", dataBindTo));
                    //input.Attributes.Add("title", string.Format("render bool as: {0}", RendBool));
                    break;

                default:
                    input.InnerHtml.AppendHtml("{{" + dataBindTo + "}}");
                    // TODO: remove or set in compiler direcive, for debugging
                    input.Attributes.Add("title", string.Format("unhandled datatype: {0}, nullable:{1}", dataType, isNullable));
                    break;
            }

            input.TagRenderMode = TagRenderMode.Normal;
            output.PostContent.SetHtmlContent(input);

            var childContent = output.PostContent.GetContent();
            output.PostContent.SetHtmlContent(Regex.Replace(childContent, @"=""dummyvalue""", string.Empty));
        }

        /// <summary>
        /// Create the angular binding variable name
        /// </summary>
        /// <remarks>
        /// If bind-pa (parentname) and bind-to (property name override) are not supplied, then the name of the variable used for 
        /// angular data-binding is taken directly from the view model property name.
        /// If parent (bind-pa) and override name (bind-to) are both supplied the angular data-bind variable is set to bindapa.bindto
        /// If the bind-to is supplied and bind-pa (parent) not supplied, then only the bind-to is used
        /// </remarks>
        /// <param name="bindPa">optional parent name</param>
        /// <param name="bindTo">optional property name, to override model property</param>
        /// <param name="propertyName">property name from viewModel property</param>
        /// <returns></returns>
        private string GetDataBindVariableName(string bindPa, string bindTo, string propertyName)
        {
            var varName = bindTo ?? propertyName;
            return (bindPa != null) ? string.Format("{0}.{1}", bindPa, varName) : varName;
        }
    }
}
