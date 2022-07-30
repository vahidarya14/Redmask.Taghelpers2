using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("filterPanel")]
    [HtmlTargetElement("div", Attributes = "filterPanel")]
    public class FilterPanelTaghelper : TagHelper
    {
        [HtmlAttributeName("showDefaultInput")] public bool ShowDefaultInput { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var c = (await output.GetChildContentAsync()).GetContent();
            var html = @$"
    <button class='btn btn-sm btn-search d-none'>جستجو</button>
<script>
      $(document).mouseup(function (e) {{let container = $(e.target).closest('.btn-group');
        if (!container.is(e.target) && container.has(e.target).length === 0) {{
            $('.dropdown-menu2').removeClass('show');
        }}
        else {{
            $('.dropdown-menu2').removeClass('show');
            let container2 = container.children('.dropdown-menu2');
            //var id1 = container.attr('id');
            //var id = container2.attr('id');
            //console.log(id);
            //// debugger;
            $(container2).addClass('show');
        }}
    }});
    $().ready(function () {{ filterOp(); }});

    $('.btn-search').click(function(){{   doFilter();    }});

var filterOp = function () {{
    $("".filterInput"").each(function () {{
        let type = $(this).attr('type');
        type = type || 'text';
        var attr = $(this).attr('data-mdpersiandatetimepicker');
        if (typeof attr !== 'undefined' && attr !== false)
            type = 'datetime';

        if (type == 'text') {{
                $(this).keypress(function (event) {{
                    let keycode = (event.keyCode ? event.keyCode : event.which);
                    if (keycode == '13') {{
                        let id = $(this).attr('id');
                        $(`#${{id}}-has`).html($(this).val());
                        doFilter2();
                    }}
                }});
        }}
        else if (type == 'checkbox') {{
            $(this).change(function (event) {{
                let c = $(this).attr('class').replace('filterInput', '').trim();
                let val = $(this).attr('data-lbl');
                let html = $(`#${{c}}-has`).html() ?? '';
                if (this.checked) {{
                    $(`#${{c}}-has`).html(html + '<span class=""badge badge-success ml-1"">'+val + '</span>');
                }}
                else {{
                    $(`#${{c}}-has`).html(html.replace('<span class=""badge badge-success ml-1"">'+val + '</span>', ''));
                }}
                doFilter2();
            }});
        }}
        else if (type == 'datetime') {{
            $(this).change(function (event) {{
                let id = $(this).attr('id');
                $(`#${{id}}-has`).html($(this).val());
                doFilter2();
            }});
        }}
    }});
}}

var doFilter2 = function(){{
    if(typeof doFilter === 'function' ){{
        //alert('function doFilter is not found');
        return;
    }}
    doFilter();
}}
</script>
<style>
    .btn-search{{
        background:#05f10a;
     }}

    .dropdown-menu2 
    {{
        position: absolute;
        color: black;
        border: 1px solid #d0d0d0;
        top: 32px;
        right: 0;
        width: 100%;
        min-width: 194px;
        display: none;
        z-index: 4;
        list-style: none;
        background-color: #ffffff;
        background-clip: padding-box;
        border: 1px solid rgba(0, 0, 0, 0.15);
        border-radius: 0.25rem;
        box-shadow: 0 0.5rem 1rem rgb(0 0 0 / 18%);
    }}

    .dropdown-menu2.show {{
        display: block;
    }}
</style>
";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "text-right bg-primary filter-row");
            var pre = @$"
                    <i class='la la-filter la-2x'></i>
{(ShowDefaultInput ? " <div class='btn-group'><input class='form-control form-control-sm filterInput' id='filter-keyword'></div>" : "")}";
            output.PreContent.SetHtmlContent(pre);
            output.PostContent.SetHtmlContent(html);
        }
    }
}
