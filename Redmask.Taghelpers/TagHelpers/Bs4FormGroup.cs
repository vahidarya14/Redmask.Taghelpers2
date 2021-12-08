using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("Bs4FormGroup", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class Bs4FormGroupTagHelper : TagHelper
    {
        //[HtmlAttributeName("asp-for")] public ModelExpression AspFor { get; set; }

        public string Label { get; set; } 

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var c = (await output.GetChildContentAsync()).GetContent();

            output.Content.SetHtmlContent($@"       
            <div class='form-group row'>
                <label class='col-sm-2 col-form-label'>{Label}</label>
                <div class='col-sm-10'>
                    {c}
                </div>
            </div>");
            await  base.ProcessAsync(context, output);
        }


    }
}
