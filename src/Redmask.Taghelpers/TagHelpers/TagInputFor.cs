using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("TagInputFor", Attributes = "asp-for", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class TagInputForTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression Model { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($@"
    <input data-role='tagsinput' value='{Model.Model?.ToString().Replace(", ", ",") ?? ""}' id='{Model.Name}_2' />
    <input value='@({Model.Model})' name='{Model.Name}' id='{Model.Name}' type='hidden' />
    <script>
        $('#{Model.Name}_2').on('itemAdded',   function (e) {{ $('[name={Model.Name}]').val($(this).tagsinput()[0].itemsArray.join(', ')); }});
        $('#{Model.Name}_2').on('itemRemoved', function (e) {{ $('[name={Model.Name}]').val($(this).tagsinput()[0].itemsArray.join(', ')); }});
    </script>
");
        }

    }
}
