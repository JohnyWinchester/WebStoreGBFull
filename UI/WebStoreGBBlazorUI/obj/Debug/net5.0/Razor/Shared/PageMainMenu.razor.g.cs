#pragma checksum "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\PageMainMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "819c455c76fb33e3afd40c96669e811cb4c577cd"
// <auto-generated/>
#pragma warning disable 1591
namespace WebStoreGBBlazorUI.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using WebStoreGBBlazorUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\_Imports.razor"
using WebStoreGBBlazorUI.Shared;

#line default
#line hidden
#nullable disable
    public partial class PageMainMenu : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<div class=""navbar-header""><button type=""button"" class=""navbar-toggle"" data-toggle=""collapse"" data-target="".navbar-collapse""><span class=""sr-only"">Toggle navigation</span>
        <span class=""icon-bar""></span>
        <span class=""icon-bar""></span>
        <span class=""icon-bar""></span></button></div>
");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "mainmenu pull-left");
            __builder.OpenElement(3, "ul");
            __builder.AddAttribute(4, "class", "nav navbar-nav collapse navbar-collapse");
            __builder.AddMarkupContent(5, "<li><a href=\"/\" class=\"active\">Home</a></li>\r\n        ");
            __builder.OpenElement(6, "li");
            __builder.AddAttribute(7, "class", "dropdown");
            __builder.AddMarkupContent(8, "<a href=\"#\">??????????????<i class=\"fa fa-angle-down\"></i></a>\r\n            ");
            __builder.OpenElement(9, "ul");
            __builder.AddAttribute(10, "role", "menu");
            __builder.AddAttribute(11, "class", "sub-menu");
            __builder.OpenElement(12, "li");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(13);
            __builder.AddAttribute(14, "href", "/catalog");
            __builder.AddAttribute(15, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(16, "??????????????");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n\r\n        ");
            __builder.OpenElement(18, "li");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(19);
            __builder.AddAttribute(20, "href", "/contacts");
            __builder.AddAttribute(21, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(22, "????????????????");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n        ");
            __builder.OpenElement(24, "li");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.NavLink>(25);
            __builder.AddAttribute(26, "href", "/about");
            __builder.AddAttribute(27, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(28, "?? ??????????????????");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
