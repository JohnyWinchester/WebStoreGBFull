#pragma checksum "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59746240783726960c6eaade9e9c6f4b26287abe"
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
#nullable restore
#line 1 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
using WebStoreGBBlazorUI.Models;

#line default
#line hidden
#nullable disable
    public partial class ProductView : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-sm-4");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "product-image-wrapper");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "single-products");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "productinfo text-center");
            __builder.OpenElement(8, "img");
            __builder.AddAttribute(9, "src", "images/shop/" + (
#nullable restore
#line 6 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
                                       Product.Image

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "alt");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.OpenElement(12, "h2");
#nullable restore
#line 7 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
__builder.AddContent(13, Product.Price.ToString("C"));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                ");
            __builder.OpenElement(15, "p");
#nullable restore
#line 8 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
__builder.AddContent(16, Product.Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                ");
            __builder.AddMarkupContent(18, "<a href=\"#\" class=\"btn btn-default add-to-cart\"><i class=\"fa fa-shopping-cart\"></i>В корзину</a>");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "product-overlay");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "overlay-content");
            __builder.OpenElement(24, "h2");
#nullable restore
#line 13 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
__builder.AddContent(25, Product.Price.ToString("C"));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                    ");
            __builder.OpenElement(27, "p");
#nullable restore
#line 14 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
__builder.AddContent(28, Product.Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                    ");
            __builder.AddMarkupContent(30, "<a href=\"#\" class=\"btn btn-default add-to-cart\"><i class=\"fa fa-shopping-cart\"></i>В корзину</a>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n        ");
            __builder.AddMarkupContent(32, "<div class=\"choose\"><ul class=\"nav nav-pills nav-justified\"><li><a href=\"#\"><i class=\"fa fa-plus-square\"></i>Добавить в желания</a></li>\r\n                <li><a href=\"#\"><i class=\"fa fa-plus-square\"></i>Добавить к сравнению</a></li></ul></div>");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGBBlazorUI\Shared\ProductView.razor"
 
    [Parameter]
    public ProductInfo Product { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
