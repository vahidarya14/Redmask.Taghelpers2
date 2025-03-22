using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers;

[HtmlTargetElement("PersianDatePickerBs5For", Attributes = DescriptionAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
public class PersianDatePickerBs5ForTagHelper : TagHelper
{
    private const string DescriptionAttributeName = "asp-for";

    [HtmlAttributeName(DescriptionAttributeName)]
    public ModelExpression Model { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var dt = Model.Model != null ? (DateTime?)Model.Model : null;
        //var isUtc = dt.Value.Kind == DateTimeKind.Utc;
        var enabletimepicker = "true";

        var val1 = $"{(!dt.HasValue ? "" :$"{dt.Value.Year}-{dt.Value.Month.ToString().PadLeft(2,'0')}-{dt.Value.Day.ToString().PadLeft(2, '0')}")}";
        //{ ScriptHelper.AddJquery()}
        //{ ScriptHelper.AddScript("/lib/MD.BootstrapPersianDateTimePicker/jalaali.js")}
        //{ ScriptHelper.AddScript("/lib/MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.js")}
        //<link href = '/lib/MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.style.css' rel = 'stylesheet' >
        output.Content.SetHtmlContent($@"
<div class='input-group mb-3'>
        <input class='form-control' id='{Model.Name}2' value='{(!dt.HasValue ? "" : ToPersian(dt.Value))}'>
        <input type='hidden' id='{Model.Name}'  name='{Model.Name}'  value='{val1}'  />
        <div class='input-group-prepend'>
            <span class='input-group-text pt-0 pb-0 pl-1 pr-1' ><i class='las la-calendar-alt la-2x'></i></span>
        </div>
</div>

<script> 
   
     $(document).ready(function () {{ 
        new mds.MdsPersianDateTimePicker(document.getElementById('{Model.Name}2'), {{
            targetTextSelector: '#{Model.Name}2',
            targetDateSelector: '#{Model.Name}',
            enableTimePicker: true,
            dateFormat: 'yyyy-MM-dd',
            textFormat: 'yyyy/MM/dd',
        }});
        setTimeout(()=>{{$('#{Model.Name}').val('{val1}');$('#{Model.Name}2').val('{(!dt.HasValue ? "" : ToPersian(dt.Value))}');}},100);
 }})
</script> 
");

        output.TagMode = TagMode.StartTagAndEndTag;
    }
    public static string ToPersian(DateTime d, bool includeTime = false)
    {
        PersianCalendar pc = new();
        return !includeTime ? $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00}" :
            $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00} {d.Hour:00}:{d.Minute:00}";
    }
}