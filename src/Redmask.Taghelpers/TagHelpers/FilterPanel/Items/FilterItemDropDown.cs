using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("dropDownFilterItem")]
    public class FilterItemDropDownTaghelper : TagHelper
    {
        [HtmlAttributeName("id")] public string id { get; set; }
        [HtmlAttributeName("title")] public string title { get; set; }
        [HtmlAttributeName("iconClass")] public string iconClass { get; set; } = "las la-angle-down";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var html = @$"
                <button type='button' class='btn text-white' data-toggle='dropdown' aria-expanded='false'>
                    {title}:<span class='badge badge-warning' id='{id}-has'></span>
                    <i class='{iconClass}'></i>
                </button>
                <div class='dropdown-menu2 p-1 pt-3' id='f3'>                  
                    <div class='input-group mb-3'>
                        <input class='form-control form-control-sm filterInput' id='{id}' />
                        <div class='input-group-prepend'>
                             <button type='button' class='input-group-text py-0 px-1' id='clear-{id}'>X</button>
                        </div>
                    </div>
                </div>
                <script>
                    $('#clear-{id}').click(function(){{  
                              $('#{id}').val(''); 
                              var e = $.Event('keypress');
                              e.which = 13;
                              $('#{id}').trigger(e);  
                        }});
                </script>    ";

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "btn-group");
            output.Content.AppendHtml(html);
        }
    }
}
