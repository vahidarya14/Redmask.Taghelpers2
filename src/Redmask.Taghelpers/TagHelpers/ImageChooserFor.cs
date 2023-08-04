using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers
{
    [HtmlTargetElement("imageChooserFor", Attributes = "asp-for", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ImageChooserForTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")] public ModelExpression Model { get; set; }

        public string FolderPath { get; set; }
        public int MaxKb { get; set; } = 8000;
        public double MinRatioHeightToWidth { get; set; } = .001;
        public double MaxRatioHeightToWidth { get; set; } = 100;
        public string DefaultAvatar { get; set; } = "/_content/Redmask.Taghelpers/noIimage268.png";
        public string ImgCss { get; set; }
        public string ImgClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var src = Model.Model != null ? FolderPath + Model.Model : DefaultAvatar;
            var imgId = Model.Name + Guid.NewGuid().ToString().Split('-')[0];
            var fileId = Model.Name + "file";
            var maxAllowedKillobyte = (MaxKb + 6) * 1000;

            output.Content.SetHtmlContent($@"
<img src='{ src}' id='{imgId}' style='height:100%; cursor:pointer;min-height:50px;border:1px dashed red;{ImgCss}' class='{ImgClass}' />
<input type='file' name='{fileId}' id='{fileId}' style='display:none' accept='image/*' />
<button id='del_img_{fileId}' type='button' class='btn p-0' style='position: absolute;
                                                               margin-right: -30px;
                                                               background: #ffc0cba1;
                                                               color: red;
                                                               width: 29px;
                                                               height: 29px;'><i class='las la-trash la-2x'></i></button>
<script>
    $('#{imgId}').click(function () {{ $('#{fileId}').trigger('click'); }});
    $('#{fileId}').on('change', function (evt) {{   
                                                    
             var tgt = evt.target || window.event.srcElement,                                           
                 files = tgt.files;                                                                     
             if (FileReader && files && files.length) {{                                                 
                                                                                                        
                 if (files[0].size > { maxAllowedKillobyte}) {{                                                           
                     alert('حجم عکس باید کمتر از   {MaxKb}  کیلوبایت باشد');                                
                     $('#{fileId}').val('');                                                           
                     return;                                                                            
                 }};                                                                                     
                 var fr = new FileReader();                                                             
                 fr.onload = function () {{                                                              
                                                                                                        
                     var image = new Image();                                                           
                     image.src = fr.result;                                                             
                     image.onload = function () {{                                                       
                         var height = this.height;                                                      
                         var width = this.width;                                                        
                         if (!(height >= { MinRatioHeightToWidth} * width && height <=  {MaxRatioHeightToWidth} * width)) {{                         
                             alert('ارتفاع تصویر باید بین { MinRatioHeightToWidth} تا { MaxRatioHeightToWidth} برابر عرض تصویر باشد');           
                             $('#{ fileId}').val('');                                                   
                             $('#s-btn').css('display', 'none');                                        
                             return false;                                                              
                         }}                                                                              
                                                                                                        
                         document.getElementById('{ imgId }').src = fr.result;                      
                         $('#s-btn').css('display', '');                                                
                         return true;                                                                   
                     }};                                                                                 
                 }};                                                                                     
                 fr.readAsDataURL(files[0]);                                                            
             }}   
             else{{}}
     }});  
    $('#del_img_{fileId}').click(function () {{  document.getElementById('{imgId}').src ='{DefaultAvatar}';document.getElementById('{fileId}').value = null; }});
</script>");



        }
    }
}
