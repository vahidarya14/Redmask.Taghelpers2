using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("FloatingLabelInputGroupFor",Attributes = DescriptionAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class FloatingLabelInputGroupForTagHelper: TagHelper
    {
        private const string DescriptionAttributeName = "asp-for";
        [HtmlAttributeName(DescriptionAttributeName)] public ModelExpression Model { get; set; }
        
        public string Label { get; set; } 
        
        public string Addon { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var c = (await output.GetChildContentAsync()).GetContent();

            output.Content.SetHtmlContent($@"<div class='form-group input-group'>
                                                <span class='input-group-addon'>{Addon}</span>
                                                 <div class='has-float-label'>
                                                     {c}
                                                     <label>{Label}</label>
                                                 </div>
                                             </div>");
            await  base.ProcessAsync(context, output);
        }
    }
}