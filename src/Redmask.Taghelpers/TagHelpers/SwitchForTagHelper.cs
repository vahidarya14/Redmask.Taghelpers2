using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("SwitchFor", Attributes = "asp-for", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SwitchForTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")] public ModelExpression Model { get; set; }

        public string Label { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var b = bool.Parse(Model.Model.ToString() ?? "false");
            output.Content.SetHtmlContent($@"       
<div class='custom-control custom-switch'>
    <input type='checkbox' class='custom-control-input' value='true' {(b?"checked":"")} name='{Model.Name}' id='{Model.Name}'>
    <label class='custom-control-label' for='{Model.Name}'> {Label}</label>
</div>");
            return base.ProcessAsync(context, output);
        }
    }
}