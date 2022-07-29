using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Redmask.Taghelpers.TagHelpers
{
    class FilterItemContext
    {
        public IHtmlContent Body { get; set; }
        public IHtmlContent Badge { get; set; }
    }


    [HtmlTargetElement("filterItem")]
    [RestrictChildren("filterBadge", "filterBody")]
    public class FilterItemTagHelper : TagHelper
    {
        [HtmlAttributeName("id")] public string id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = new FilterItemContext();
            context.Items.Add(typeof(FilterItemTagHelper), modalContext);

            await output.GetChildContentAsync();

            //var html = @$"
            //<div class='btn-group' >
            //    <button type='button' class='btn text-white' data-toggle='dropdown' aria-expanded='false'>
            //        {modalContext.Badge}
            //    </button>
            //    <div class='dropdown-menu2 p-1 pt-3' id='f3'>
            //        {modalContext.Body}
            //    </div>
            //</div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "btn-group");
            output.Content.AppendHtml(@$"
                <button type='button' class='btn text-white' data-toggle='dropdown' aria-expanded='false'>");
            output.Content.AppendHtml(modalContext.Badge);
            output.Content.AppendHtml(@$"</button>
                <div class='dropdown-menu2 p-1 pt-3' id='f3'>");
            output.Content.AppendHtml(modalContext.Body);
            output.Content.AppendHtml(@$"
            </div>");
        }
    }

    [HtmlTargetElement("filterBadge", ParentTag = "FilterItem")]
    public class BadgeFilterItemTaghelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (FilterItemContext)context.Items[typeof(FilterItemTagHelper)];
            modalContext.Badge = childContent;
            output.SuppressOutput();
        }
    }


    [HtmlTargetElement("filterBody", ParentTag = "FilterItem")]
    public class BodyFilterItemTaghelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (FilterItemContext)context.Items[typeof(FilterItemTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}
