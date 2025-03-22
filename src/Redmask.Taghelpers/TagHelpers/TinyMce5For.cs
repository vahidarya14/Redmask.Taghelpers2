using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Redmask.Taghelpers.TagHelpers;

[HtmlTargetElement("TinyMce5For", Attributes = "asp-for", TagStructure = TagStructure.NormalOrSelfClosing)]
public class TinyMce5ForTagHelper : TagHelper
{
    [HtmlAttributeName("asp-for")]
    public ModelExpression AspFor { get; set; }

    public string Language { get; set; }// = "fa_IR";
    public string Directionality { get; set; } //= "rtl";


    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(() =>
        {
            var Id = AspFor.Name;
            var c = AspFor.Model;
            string encodedChildContent = WebUtility.HtmlEncode(c?.ToString() ?? string.Empty);


            //{ScriptHelper.AddJquery()}
            //{ScriptHelper.AddScript("/lib/tinymce5/tinymce.min.js")}
            var aa = $@"<textarea name='{Id}' id='{Id}' class='form-control' >{encodedChildContent}</textarea>
<script>
    $().ready(function () {{

        tinyMCE.init({{
            selector: '#{Id}',
            language: '{Language}',
            //mode: 'textareas',
            //theme: 'modern',
            //inline_styles: true,
            menubar: false,
            fontsize_formats: '8pt 9pt 10pt 11pt 12pt 26pt 36pt',
            height: 200,
            width: '100%',
            autoresize_min_height: 200,
            autoresize_max_height: 200,
            menubar: true,
            plugins: [
                ' autolink autoresize directionality lists link image charmap print preview anchor',
                'searchreplace visualblocks code fullscreen textcolor',
                'insertdatetime media table contextmenu paste fullpage  codesample emoticons'
            ],
            directionality: '{Directionality}',
            codesample_languages: [
                {{ text: 'HTML/XML', value: 'markup' }},
                {{ text: 'JavaScript', value: 'javascript' }},
                {{ text: 'CSS', value: 'css' }},
                {{ text: 'JSON', value: 'json' }},
                {{ text: 'SQL', value: 'sql' }},
                {{ text: 'C#', value: 'csharp' }},
                {{ text: 'Java', value: 'java' }},
                {{ text: 'Python', value: 'python' }},
                {{ text: 'PHP', value: 'php' }},
                {{ text: 'C', value: 'c' }},
                {{ text: 'C++', value: 'cpp' }},
                {{ text: 'docker', value: 'docker' }},
            ],
            toolbar1: 'fullscreen | undo redo |forecolor backcolor |rtl ltr| styleselect | fontselect | fontsizeselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link | code codesample image emoticons ',
            codesample_global_prismjs: true,
            file_picker_callback_types: 'file image media',
            file_picker_callback: (callback, value, type)=> {{

                        var roxyFileman = '/_content/Redmask.Taghelpers/fileman/index.html';
                        roxyFileman += (roxyFileman.indexOf('?') < 0 ? '?' : '&') + 'type=' + type.filetype;
                        if (value)
                            roxyFileman += '&value=' + value; // a link to already chosen image if it exists
                        if (tinyMCE.activeEditor.settings.language)
                            roxyFileman += '&langCode=' + tinyMCE.activeEditor.settings.language;
                        const instanceApi = tinyMCE.activeEditor.windowManager.openUrl({{
                            title: 'Roxy Fileman',
                            url: roxyFileman,
                            width: 650,
                            height: 650,
                            plugins: 'media',
                            onMessage: function(dialogApi, details) {{
                                callback(details.content);
                                instanceApi.close();
                            }}
                        }});
                        return false;                   
            }},
            images_upload_handler: (blobInfo, success, failure) => {{
                var xhr, formData;

                xhr = new XMLHttpRequest();
                xhr.withCredentials = false;
                xhr.open('POST', '/UploadFilesAsync');

                xhr.onload = function () {{
                    var json;
                    if (xhr.status !== 200) {{
                        failure('HTTP Error: ' + xhr.status);
                        return;
                    }}
                    json = JSON.parse(xhr.responseText);

                    console.log(json);

                    if (!json || typeof json.location !== 'string') {{
                        failure('Invalid JSON: ' + xhr.responseText);
                        return;
                    }}
                    success(json.location);
                }};

                formData = new FormData();
                formData.append('file', blobInfo.blob(), blobInfo.filename());
                xhr.send(formData);
            }}

        }});


    }});
    </script>";
            output.Content.SetHtmlContent(aa);
            output.TagMode = TagMode.StartTagAndEndTag;
        });

    }
}
