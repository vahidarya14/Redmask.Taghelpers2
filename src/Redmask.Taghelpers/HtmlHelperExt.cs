using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redmask.Taghelpers;

public static class HtmlHelperExt
{
    public static IHtmlContent RedmaskJs(this IHtmlHelper html, ScriptsPool a) => a.ToString();

    public static IHtmlContent RedmaskCss(this IHtmlHelper html, CssPool a) => a.ToString();
}

public enum Bootstrap
{
    v4,v5
}
public class ScriptsPool
{
    private const string Package = "/_content/Redmask.Taghelpers/lib/";
    private List<string> Js = new()
    {
        $"<script src='{Package}jquery/jquery.min.js' ></script>"
    };
    Bootstrap _bootstrapVersion;

    public ScriptsPool(Bootstrap bootstrapVersion=Bootstrap.v5)
    {
        _bootstrapVersion=bootstrapVersion;

        if (_bootstrapVersion == Bootstrap.v5)
            Bootstrap5();
        else
            Bootstrap4();
    }

    public ScriptsPool Bootstrap5()
    {
        if (Js.Any(x => x.Contains("bootstrap4")))
            throw new Exception("remove Bootstrap4()");

        Js.Add($"<script src='{Package}bootstrap5/popper.min.js' ></script>");
        Js.Add($"<script src='{Package}bootstrap5/bootstrap.bundle.min.js'  ></script>");
        return this;
    }

    [Obsolete]
    public ScriptsPool Bootstrap4()
    {
        if (Js.Any(x => x.Contains("bootstrap5")))
            throw new Exception("remove Bootstrap5()");

        Js.Add($"<script src='{Package}bootstrap4/js/bootstrap.bundle.min.js'></script>");
        return this;
    }

    public ScriptsPool ModalHelper()
    {
        Js.Add($"<script src='{Package}ModalHelper.js'></script>");
        return this;
    }
    
    public ScriptsPool Helper()
    {
        Js.Add($"<script src='{Package}Helper.js'></script>");
        Js.Add($"<script src='{Package}Helper2.js'></script>");
        return this;
    }



    public ScriptsPool PersianDateTimePickerBs5()
    {
        if (!Js.Any(x => x.Contains("bootstrap5")))
            throw new Exception("user Bootstrap5() instead of Bootstrap4()");

        Js.Add($"<script src='{Package}MD.BootstrapPersianDateTimePicker.bs5/mds.bs.datetimepicker.js'></script>");
        return this;
    }

    public ScriptsPool PersianDateTimePickerBs4()
    {
        if (!Js.Any(x => x.Contains("bootstrap4")))
            throw new Exception("user Bootstrap4() instead of Bootstrap5()");

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

    public ScriptsPool TagInput()
    {
        Js.Add($"<script src='{Package}Bootstrap-4-Tag-Input-Plugin-jQuery/tagsinput.js'></script>");
        return this;
    }

    public new HtmlString ToString() => new (string.Join("\r\n", Js));
}

public class CssPool
{
    private const string package = "/_content/Redmask.Taghelpers/lib/";
    private List<string> Css = new()
    {
        "main.css",
        "line-awesome-1.3.0/css/line-awesome.min.css"
    };
    Bootstrap _bootstrapVersion;

    public CssPool(Bootstrap bootstrapVersion = Bootstrap.v5)
    {
        _bootstrapVersion = bootstrapVersion;

        if (_bootstrapVersion == Bootstrap.v5)
            Bootstrap5();
        else
            Bootstrap4();
    }

    public CssPool Bootstrap5()
    {
        if (Css.Any(x => x.Contains("bootstrap4")))
            throw new Exception("remove Bootstrap4()");

        Css.Add($"bootstrap5/bootstrap.min.css");
        return this;
    }

    [Obsolete]
    public CssPool Bootstrap4()
    {
        if (Css.Any(x => x.Contains("bootstrap5")))
            throw new Exception("remove Bootstrap5()");

        Css.Add($"bootstrap4/css/bootstrap.min.css");
        return this;
    }

    public CssPool PersianDateTimePickerBs5()
    {
        if (!Css.Any(x => x.Contains("bootstrap5")))
            throw new Exception("user Bootstrap5() instead of Bootstrap4()");

        Css.Add($"MD.BootstrapPersianDateTimePicker.bs5/mds.bs.datetimepicker.style.css");
        return this;
    }

    public CssPool PersianDateTimePickerBs4()
    {
        if (!Css.Any(x => x.Contains("bootstrap4")))
            throw new Exception("user Bootstrap4() instead of Bootstrap5()");

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

    public CssPool TagInput()
    {
        Css.Add($"Bootstrap-4-Tag-Input-Plugin-jQuery/tagsinput.css");
        return this;
    }

    public new HtmlString ToString() => new(
        string.Join("\r\n", Css.Select(x => $"<link href='{package}{x}' rel='stylesheet' />"))
        );

}