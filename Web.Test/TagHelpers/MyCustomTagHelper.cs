using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Web.Test.TagHelpers
{
    //usage: <employee-details for-name ="Name" for-designation="Designation"></employee-details> 
    [HtmlTargetElement("employee-details")]

    //usage:  <div employee-details for-name ="Name" for-designation="Description"  >ssss</div>
    [HtmlTargetElement("div", Attributes = "employee-details")]
    public class MyCustomTagHelper : TagHelper
    {
        [HtmlAttributeName("for-name")]
        public ModelExpression EmployeeName { get; set; }

        [HtmlAttributeName("for-designation")]
        public ModelExpression Designation { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "EmployeeDetails";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<span>Name: {0}</span> <br/>", EmployeeName.Model);
            sb.AppendFormat("<span>Designation: {0}</span>", Designation.Model);

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
