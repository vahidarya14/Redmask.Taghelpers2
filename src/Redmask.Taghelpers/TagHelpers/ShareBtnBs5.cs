using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers;

[HtmlTargetElement("ShareBtnBs5", TagStructure = TagStructure.NormalOrSelfClosing)]
public class ShareBtnBs5TagHelper : TagHelper
{
    [ViewContext] public ViewContext ViewContext { get; set; }
    HttpRequest Request => ViewContext.HttpContext.Request;

    public string Subject { get; set; }
    public string Url { get; set; }
    public bool UseCurrentUrl { get; set; } = true;

    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var customeClass = context.AllAttributes.FirstOrDefault(x => x.Name.ToLower() == "class")?.Value ?? "";
        var currentUrl = UseCurrentUrl ? $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}" : Url;
        //var aaa = Request.GetDisplayUrl();
        output.Content.SetHtmlContent($@"       
<div class='dropdown'>
      <button class='btn btn-sm {customeClass}' type='button' data-bs-toggle='dropdown' aria-expanded='false'>
        <i class='las la-share-alt-square la-2x'></i>
    </button>
    <div class='dropdown-menu' >
        <a class='dropdown-item text-left' href='https://www.facebook.com/sharer.php?u={currentUrl}&t={Subject}' target='_blank'> <i class='icofont-facebook'></i> Facebook</a>
        <a class='dropdown-item text-left' href='http://www.linkedin.com/shareArticle?mini=true&title={Subject}&url={currentUrl}' target='_blank'> <i class='icofont-linkedin'></i> Linkedin</a>
        <a class='dropdown-item text-left' href='https://twitter.com/home?status=Reading:{currentUrl}' title='اشتراک گذاری در تویینر' target='_blank'><i class='icofont-twitter'></i> twitter</a>
        <a class='dropdown-item text-left' href='https://telegram.me/share/url?text={Subject}&url={currentUrl}' target='_blank' title='اشتراک گذاری در تلگرام'><i class='icofont-telegram'></i> telegram</a>
        <a class='dropdown-item text-left' href='https://api.whatsapp.com/send?text={currentUrl}' target='_blank' >واتساپ <i class='icofont-whatsapp'></i></a>
    </div>
</div>");
        output.TagMode = TagMode.StartTagAndEndTag;
        return base.ProcessAsync(context, output);
    }
}