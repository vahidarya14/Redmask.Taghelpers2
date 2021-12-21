using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redmask.Taghelpers
{
    public static class HtmlHelperExt
    {
        public static IHtmlContent RedmaskJs(this IHtmlHelper html, ScriptsPool a) => a.ToString();

        public static IHtmlContent RedmaskCss(this IHtmlHelper html, CssPool a) => a.ToString();
    }

    public class ScriptsPool
    {
        private const string Package = "/_content/Redmask.Taghelpers/lib/";
        private List<string> Js = new()
        {
            $"<script src='{Package}jquery/jquery.min.js' ></script>"
        };

        public ScriptsPool Bootstrap4()
        {
            Js.Add($"<script src='{Package}bootstrap/js/bootstrap.bundle.min.js'></script>");
            return this;
        }

        public ScriptsPool PersianDateTimePicker()
        {
            Js.Add($"<script src='{Package}MD.BootstrapPersianDateTimePicker/jalaali.js'></script>");
            Js.Add($"<script src = '{Package}MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.js' ></script> ");

            return this;
        }

        public ScriptsPool Kendo2020()
        {
            Js.Add($"<script src='{Package}kendo2020/kendo.all.min.js'></script>");
            return this;
        }


        public ScriptsPool AdminLTE()
        {
            Js.Add($"<script src='{Package}AdminLTE-3.0.2/js/adminlte.js'></script>");
            return this;
        }

        public ScriptsPool TinyMCE5()
        {
            Js.Add($"<script src='{Package}tinymce5/tinymce.min.js'></script>");
            return this;
        }

        public new HtmlString ToString() => new (string.Join("\r\n", Js));
    }

    public class CssPool
    {
        private const string package = "/_content/Redmask.Taghelpers/lib/";
        private List<string> Css = new()
        {
            "line-awesome-1.3.0/css/line-awesome.min.css"
        };

        public CssPool Bootstrap4()
        {
            Css.Add($"bootstrap/css/bootstrap.min.css");
            return this;
        }

        public CssPool PersianDateTimePicker()
        {
            Css.Add($"MD.BootstrapPersianDateTimePicker/jquery.md.bootstrap.datetimepicker.style.css");
            return this;
        }

        public CssPool Kendo2020()
        {
            Css.Add($"kendo2020/kendo.default-v2.min.css");
            return this;
        }

        public CssPool AdminLTE()
        {
            Css.Add($"AdminLTE-3.0.2/css/adminlte.css");
            return this;
        }

        public CssPool PersianCss()
        {
            Css.Add($"persian.css");
            return this;
        }

        public new HtmlString ToString() => new(
            string.Join("\r\n", Css.Select(x => $"<link href='{package}{x}' rel='stylesheet' />"))
            );

    }
}