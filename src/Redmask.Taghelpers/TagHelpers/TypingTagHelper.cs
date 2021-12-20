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
    .bubble {{
        background - color: #fac400;
        height: 36px;
        width: 64px;
        padding: 0 8px;
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        border-radius: 18px;
        border-top-right-radius: 4px;
    }}
    .dot {{
        width: 8px;
        height: 8px;
        border-radius: 50%;
        background-color: #eeeeee;
        animation: bounce 1000ms infinite;
    }}
    .dot:nth-of-type(2) {{
        -wekit - animation - delay: 50ms;
        animation-delay: 50ms;
    }}
    .dot:nth-of-type(3) {{
        -wekit - animation - delay: 100ms;
        animation-delay: 100ms;
    }}
    @keyframs bounce {{
         0%{{ transform: translateY(0);}}
        20%{{ transform: translateY(5px);}}
        40%{{ transform: translateY(0);}}
    }}
</style>
");
        }

    }
}