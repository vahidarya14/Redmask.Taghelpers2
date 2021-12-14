using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("PersianDatePicker", Attributes = DescriptionAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PersianDatePickerTagHelper : TagHelper
    {
        private const string DescriptionAttributeName = "id";

        [HtmlAttributeName(DescriptionAttributeName)]
        public string Id { get; set; }

        [HtmlAttributeName("dt")]
        public DateTime? Value { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var dt = Value;
            var enabletimepicker = "true";

            //{ ScriptHelper.AddJquery()}
            //{ ScriptHelper.AddScript("/lib/MD.BootstrapPersianDateTimePicker/jalaali.js")}
            //{ ScriptHelper.AddScript("/lib/MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.js")}
            //<link href = '/lib/MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.style.css' rel = 'stylesheet' >
            output.Content.SetHtmlContent($@"
<div class='input-group mb-3'>
        <input class='form-control' id='{Id}2' value='{(!dt.HasValue ? "" : ToPersian(dt.Value))}'>
        <input type='hidden' id='{Id}'  name='{Id}'  value='{dt}'  />
        <div class='input-group-prepend'>
            <span class='input-group-text' id='basic-addon1'><i class='icofont-calendar'></i></span>
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
        }
        public static string ToPersian(DateTime d, bool includeTime = false)
        {
            PersianCalendar pc = new();
            return !includeTime ? $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00}" :
                $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00} {d.Hour:00}:{d.Minute:00}";
        }
    }
}
