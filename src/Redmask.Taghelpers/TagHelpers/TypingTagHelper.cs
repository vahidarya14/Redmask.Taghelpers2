using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("Typing",  TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TypingTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($@"
<div class='bubble'>
    <div class='dot'></div>
    <div class='dot'></div>
    <div class='dot'></div>
</div>
<style>

</style>
");
        }

    }
}