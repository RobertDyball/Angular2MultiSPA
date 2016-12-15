using Microsoft.AspNetCore.Razor.TagHelpers;
using NUnit.Framework;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Angular2MultiSPA.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Angular2MultiSPA.UnitTests
{
    [TestFixture]
    public class TagDaHelperTests
    {
        [Test]
        public void PassingTest()
        {
            var sampleData = new SampleData();
         //   var propertyType = ((DefaultModelMetadata)sampleData).Properties["DateTimeVar"];
            //ModelExpression modelProperty;// = typeof(SampleData)
            var attributes = new List<TagHelperAttribute>();
           // var attributeItem = new TagHelperAttribute("for", modelProperty);
            //attributes.Add(attributeItem);
            bool? passedUseCacheResult = null;
            HtmlEncoder passedEncoder = null;
            var content = new DefaultTagHelperContent();
            var output = new TagHelperOutput(
                tagName: "tag-da",
                attributes: new TagHelperAttributeList(attributes),
                getChildContentAsync: (useCachedResult, encoderArgument) =>
                {
                    passedUseCacheResult = useCachedResult;
                    passedEncoder = encoderArgument;
                    return Task.FromResult<TagHelperContent>(content);
                });

            Assert.AreEqual(output.ToString(), "<input ");
        }

        [Test]
        public void FailingTest()
        {
            Assert.AreEqual(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
