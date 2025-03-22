using System;
using System.Globalization;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers;

[HtmlTargetElement("PersianDatePickerBs4", Attributes = DescriptionAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class PersianDatePickerBs4TagHelper : TagHelper
{
    private const string DescriptionAttributeName = "id";
    [HtmlAttributeName(DescriptionAttributeName)] public string Id { get; set; }

    [HtmlAttributeName("class")] public string ClassInput { get; set; }

    [HtmlAttributeName("dt")] public DateTime? Value { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var dt = Value;

        output.Content.SetHtmlContent($@"
<div class='input-group mb-3'>
        <input class='form-control {ClassInput}' id='{Id}2' value='{(!dt.HasValue ? "" : ToPersian(dt.Value))}'>
        <input type='hidden' id='{Id}'  name='{Id}'  value='{dt}'  />
        <div class='input-group-prepend'>
            <span class='input-group-text p-0' ><i class='las la-calendar la-2x'></i></span>
        </div>
</div>

<script> 
   
     $(document).ready(function () {{ 
        
         $('#{Id}2').MdPersianDateTimePicker({{
                targetTextSelector: '#{Id}2',
                targetDateSelector: '#{Id}',
                enableTimePicker: false,
                dateFormat: 'yyyy-MM-dd',
                textFormat: 'yyyy/MM/dd',
         }});
    }}); 
</script> 
");
        output.TagMode = TagMode.StartTagAndEndTag;

    }
    static string ToPersian(DateTime d, bool includeTime = false)
    {
        PersianCalendar pc = new();
        return !includeTime ? $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00}" :
            $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00} {d.Hour:00}:{d.Minute:00}";
    }
}
