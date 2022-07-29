using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("customeBobyFilter")]
    public class FilterItemCustomeBobyTaghelper : TagHelper
    {
        [HtmlAttributeName("id")] public string Id { get; set; }
        [HtmlAttributeName("title")] public string Title { get; set; }
        [HtmlAttributeName("iconClass")] public string iconClass { get; set; } = "las la-angle-down";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var c = (await output.GetChildContentAsync()).GetContent();
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "btn-group");
            var html = @$"
                <button type='button' class='btn text-white' data-toggle='dropdown' aria-expanded='false'>
                    {Title}:<span class='badge badge-warning' id='{Id}-has'></span>
                    <i class='{iconClass}'></i>
                </button>
                <div class='dropdown-menu2 p-1 pt-3' id='f3'>
                    {c}
                </div>";

            output.Content.AppendHtml(html);
        }
    }
}
