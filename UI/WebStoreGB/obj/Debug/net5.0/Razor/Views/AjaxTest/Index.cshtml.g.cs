#pragma checksum "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\AjaxTest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04a295100ec3c6ceb16cce1ec420ce4b4a1a5873"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AjaxTest_Index), @"mvc.1.0.view", @"/Views/AjaxTest/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB.Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB.Domain.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04a295100ec3c6ceb16cce1ec420ce4b4a1a5873", @"/Views/AjaxTest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6372623376a06a5d98093964a4bb08040c4691ea", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AjaxTest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\AjaxTest\Index.cshtml"
  
    ViewBag.Title = "Ненавязчивый AJAX";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            WriteLiteral("        <div class=\"col-md-4\">\r\n            <h4>Рендринг нас стороне сервера</h4>\r\n\r\n            <div id=\"panel-server\">\r\n\r\n                <a class=\"btn btn-default\"\r\n                    data-ajax=\"true\"\r\n                    data-ajax-url=\"");
#nullable restore
#line 15 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\AjaxTest\Index.cshtml"
                              Write(Url.Action("GetHTML","AjaxTest", new { id = 42, msg = "Hello HTML!", Delay = "500"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                    data-ajax-update=""#panel-server""
                    data-ajax-loading=""#spinner-server"">
                    Загрузка
                </a>

                <span id=""spinner-server"" style=""display: none"">
                    <i class=""fa fa-spinner fa-spin""></i>
                </span>
            </div>
        </div>

");
            WriteLiteral("        <div class=\"col-md-4\">\r\n            <h4>Рендринг нас стороне клиента</h4>\r\n            <a class=\"btn btn-default\"\r\n               data-ajax=\"true\"\r\n               data-ajax-url=\"");
#nullable restore
#line 33 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\AjaxTest\Index.cshtml"
                         Write(Url.Action("GetJSON","AjaxTest", new { id = 13, msg = "Hello JSON!", Delay = "2000"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
               data-ajax-loading=""#spinner-client""
               data-ajax-success=""OnJSONLoaded"">
                Загрузка
            </a>

            <span id=""spinner-client"" style=""display: none"">
                <i class=""fa fa-spinner fa-spin""></i>
            </span>

            <div id=""panel-client"">

            </div>
        </div>

");
            WriteLiteral(@"        <div class=""col-md-4"">
            <h4>Рендринг руками</h4>
            <a class=""btn btn-default"" id=""load-data-button"">
                Загрузка
            </a>

            <div id=""panel-js"">

            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-md-6"">
            <a class=""btn btn-default"" 
            data-ajax=""true"" 
            data-ajax-url=api/console/clear>Clear</a>
        </div>
        <div class=""col-md-6"">
            <a class=""btn btn-default"" 
            data-ajax=""true"" 
            data-ajax-url=""api/console/writeline?Message=Hello%20World"">WriteLine</a>
        </div>    
    </div>
</div>

");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        .row {\r\n            margin-bottom: 10px;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        OnJSONLoaded = data => {
            const panel = $(""#panel-client"");
            panel.empty();
            panel.append(""msg:"" + data.message);
            panel.append(""<br/>"");
            panel.append(""server time:"" + data.serverTime);
        }

        $(""#load-data-button"").click(e => {
            e.preventDefault();

            console.log(""Starting AJAX-request to server"");

            $.get(""");
#nullable restore
#line 101 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\AjaxTest\Index.cshtml"
              Write(Url.Action("GetJSON"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""", { id: 321, msg: ""QWE"", Delay: ""1000""})
                .done(data =>{
                    console.log(""Response from server"");
                    const panel = $(""#panel-js"");
                    panel.empty();
                    panel.append(""msg:"" + data.message);
                    panel.append(""<br/>"");
                    panel.append(""server time:"" + data.serverTime);
                }); 
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
