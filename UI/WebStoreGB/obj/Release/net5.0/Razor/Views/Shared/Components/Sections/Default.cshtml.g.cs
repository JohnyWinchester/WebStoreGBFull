#pragma checksum "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1f7fe2b8576e62a78a3a9c20b30c28c5beed9c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Sections_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Sections/Default.cshtml")]
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
#line 1 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\_ViewImports.cshtml"
using WebStoreGB.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1f7fe2b8576e62a78a3a9c20b30c28c5beed9c7", @"/Views/Shared/Components/Sections/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0264315ce9aa0df6b50f25e3cf1827bd715e016a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Sections_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SectionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Catalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h2>Категории</h2>\n<div class=\"panel-group category-products\" id=\"accordian\">\n    <!--category-productsr-->\n\n");
#nullable restore
#line 7 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
     foreach (var parent_section in Model)
    {
        if (parent_section.ChildSections.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">\n                        <h4 class=\"panel-title\">\n                            <a data-toggle=\"collapse\" data-parent=\"#accordian\"");
            BeginWriteAttribute("href", " href=\"", 483, "\"", 520, 2);
            WriteAttributeValue("", 490, "#", 490, 1, true);
#nullable restore
#line 14 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
WriteAttributeValue("", 491, parent_section.GetHashCode(), 491, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                <span class=\"badge pull-right\"><i class=\"fa fa-plus\"></i></span>\n                                ");
#nullable restore
#line 16 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                           Write(parent_section.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </a>\n                        </h4>\n                    </div>\n                    <div");
            BeginWriteAttribute("id", " id=\"", 787, "\"", 821, 1);
#nullable restore
#line 20 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
WriteAttributeValue("", 792, parent_section.GetHashCode(), 792, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"panel-collapse collapse\">\n                        <div class=\"panel-body\">\n                            <ul>\n");
#nullable restore
#line 23 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                                 foreach (var child_section in parent_section.ChildSections)
                                 {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                     <li>\n                                         ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1f7fe2b8576e62a78a3a9c20b30c28c5beed9c76506", async() => {
                WriteLiteral("\n                                            ");
#nullable restore
#line 29 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                                       Write(child_section.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n                                         ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-SectionId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                                                     WriteLiteral(child_section.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SectionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-SectionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SectionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                     </li>\n");
#nullable restore
#line 32 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\n                        </div>\n                    </div>\n                </div>\n");
#nullable restore
#line 37 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"panel panel-default\">\n                    <div class=\"panel-heading\">\n                        <h4 class=\"panel-title\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1f7fe2b8576e62a78a3a9c20b30c28c5beed9c710099", async() => {
                WriteLiteral("\n                            ");
#nullable restore
#line 44 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                       Write(parent_section.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-SectionId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
                                                                                WriteLiteral(parent_section.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SectionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-SectionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["SectionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h4>\n                    </div>\n                </div>\r\n");
#nullable restore
#line 48 "E:\GeekBrains\ASP 01\WebStoreGB\WebStoreGB\Views\Shared\Components\Sections\Default.cshtml"
        }
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div><!--/category-products-->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SectionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591