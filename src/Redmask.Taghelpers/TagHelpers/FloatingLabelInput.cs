using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("FloatingLabelInputFor", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class FloatingLabelInputForTagHelper: TagHelper
    {
        public string Label { get; set; } 

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var c = (await output.GetChildContentAsync()).GetContent();

            output.Content.SetHtmlContent($@"       
            <div class='form-group has-float-label'>
                {c}
                <label for=''>{Label}</label>
             </div>");
            await  base.ProcessAsync(context, output);
        }
    }
}