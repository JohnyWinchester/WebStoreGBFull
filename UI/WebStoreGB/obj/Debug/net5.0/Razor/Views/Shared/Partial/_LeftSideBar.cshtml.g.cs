#pragma checksum "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\Shared\Partial\_LeftSideBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "512b287c839d252636747cfaedfd5248b9cbf058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partial__LeftSideBar), @"mvc.1.0.view", @"/Views/Shared/Partial/_LeftSideBar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512b287c839d252636747cfaedfd5248b9cbf058", @"/Views/Shared/Partial/_LeftSideBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6372623376a06a5d98093964a4bb08040c4691ea", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Partial__LeftSideBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private global::AspNetCore.Views_Shared_Partial__LeftSideBar.__Generated__SectionsViewComponentTagHelper __SectionsViewComponentTagHelper;
        private global::AspNetCore.Views_Shared_Partial__LeftSideBar.__Generated__BrandsViewComponentTagHelper __BrandsViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home/shipping.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"left-sidebar\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:sections", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "512b287c839d252636747cfaedfd5248b9cbf0584420", async() => {
            }
            );
            __SectionsViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Shared_Partial__LeftSideBar.__Generated__SectionsViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__SectionsViewComponentTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 3 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\Shared\Partial\_LeftSideBar.cshtml"
                 WriteLiteral(Context.Request.Query["SectionId"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __SectionsViewComponentTagHelper.SectionId = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("section-id", __SectionsViewComponentTagHelper.SectionId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:brands", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "512b287c839d252636747cfaedfd5248b9cbf0585987", async() => {
            }
            );
            __BrandsViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Shared_Partial__LeftSideBar.__Generated__BrandsViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__BrandsViewComponentTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 5 "E:\GeekBrains\ASP 01\WebStoreGB\UI\WebStoreGB\Views\Shared\Partial\_LeftSideBar.cshtml"
             WriteLiteral(Context.Request.Query["BrandId"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __BrandsViewComponentTagHelper.BrandId = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("brand-id", __BrandsViewComponentTagHelper.BrandId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <div class=\"price-range\">\r\n        <!--price-range-->\r\n        <h2>????????</h2>\r\n        <div class=\"well text-center\">\r\n            <input type=\"text\" class=\"span2\"");
            BeginWriteAttribute("value", " value=\"", 333, "\"", 341, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-slider-min=""0"" data-slider-max=""600"" data-slider-step=""5"" data-slider-value=""[250,450]"" id=""sl2""><br />
            <b class=""pull-left"">$ 0</b> <b class=""pull-right"">$ 600</b>
        </div>
    </div><!--/price-range-->

    <div class=""shipping text-center"">
        <!--shipping-->
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "512b287c839d252636747cfaedfd5248b9cbf0588172", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div><!--/shipping-->\r\n\r\n</div>");
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
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:sections")]
        public class __Generated__SectionsViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__SectionsViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public System.String SectionId { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Sections", ProcessInvokeAsyncArgs(__context));
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
            private Dictionary<string, object> ProcessInvokeAsyncArgs(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                if (__context.AllAttributes.ContainsName("section-id"))
                {
                    args[nameof(SectionId)] = SectionId;
                }
                return args;
            }
        }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:brands")]
        public class __Generated__BrandsViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__BrandsViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public System.String BrandId { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Brands", ProcessInvokeAsyncArgs(__context));
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
            private Dictionary<string, object> ProcessInvokeAsyncArgs(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                if (__context.AllAttributes.ContainsName("brand-id"))
                {
                    args[nameof(BrandId)] = BrandId;
                }
                return args;
            }
        }
    }
}
#pragma warning restore 1591
