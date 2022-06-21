using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("FloatingLabelInputGroup",TagStructure = TagStructure.NormalOrSelfClosing)]
    //[RestrictChildren("input", "select","textarea", "inputGroupAddon")]
    public class FloatingLabelInputGroupTagHelper : TagHelper
    {
        public string Label { get; set; }

        public FloatingLabelInputGroupAddOnTagHelper Addon { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var c = (await output.GetChildContentAsync()).GetContent();
            var addOn =!c.Contains("<inputGroupAddon>")?"      ":
                        c.Split("<inputGroupAddon>")[1].Split("</inputGroupAddon>")[0];
            var input = c.Replace(addOn, "").Replace("<inputGroupAddon>", "").Replace("</inputGroupAddon>", "");

            output.Content.SetHtmlContent(
                            $@"<div class='input-group mb-3 has-float-label'>   
                                {input}
                                {(string.IsNullOrWhiteSpace(Label)?"":$"<label>{Label}</label>")}
                                {addOn.Trim()}
                            </div>");
            await base.ProcessAsync(context, output);
        }
    }

    [HtmlTargetElement("inputGroupAddon", TagStructure = TagStructure.NormalOrSelfClosing,ParentTag = "FloatingLabelInputGroup")]
    public class FloatingLabelInputGroupAddOnTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var c = (await output.GetChildContentAsync()).GetContent();

            output.Content.SetHtmlContent($@"<div class='input-group-addon p-0'>{c}</div>");
            await base.ProcessAsync(context, output);
        }
    }
}