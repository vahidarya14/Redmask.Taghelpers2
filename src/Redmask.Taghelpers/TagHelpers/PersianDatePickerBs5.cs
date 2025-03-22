using System;
using System.Globalization;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers;

[HtmlTargetElement("PersianDatePickerBs5", Attributes = DescriptionAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class PersianDatePickerBs5TagHelper : TagHelper
{
    private const string DescriptionAttributeName = "id";
    [HtmlAttributeName(DescriptionAttributeName)] public string Id { get; set; }

    [HtmlAttributeName("class")] public string ClassInput { get; set; }

    [HtmlAttributeName("dt")] public DateTime? Value { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var dt = Value;
        //var isUtc = dt.Value.Kind == DateTimeKind.Utc;
        var val1 = $"{(!dt.HasValue ? "" : $"{dt.Value.Year}-{dt.Value.Month.ToString().PadLeft(2, '0')}-{dt.Value.Day.ToString().PadLeft(2, '0')}")}";

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
        
        new mds.MdsPersianDateTimePicker(document.getElementById('{Id}2'), {{
            targetTextSelector: '#{Id}2',
            targetDateSelector: '#{Id}',
            enableTimePicker: false,
            dateFormat: 'yyyy-MM-dd',
            textFormat: 'yyyy/MM/dd',
        }});
        setTimeout(()=>{{$('#{Id}').val('{val1}');$('#{Id}2').val('{(!dt.HasValue ? "" : ToPersian(dt.Value))}');}},100);

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
