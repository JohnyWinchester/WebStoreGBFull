using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStoreGB.Domain.ViewModels;

namespace WebStoreGB.TagHelpers
{
    public class Pageing: TagHelper
    {
        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string,object> PageUrlValues { get; set; } 
            = new(StringComparer.OrdinalIgnoreCase);
        public PageViewModel PageModel { get; set; }
        [ViewContext,HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        //public IUrlHelperFactory _UrlHelperFactory { get; }

        //public Pageing(IUrlHelperFactory UrlHelperFactory)
        //{
        //    _UrlHelperFactory = UrlHelperFactory;
        //}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            //var url_helper = _UrlHelperFactory.GetUrlHelper(ViewContext);
            for (var i = 1; i <= PageModel.TotalPages; i++)
                ul.InnerHtml.AppendHtml(CreateElement(i/*, url_helper*/));
            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateElement(int PageNumber/*, IUrlHelper Url*/)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");
            a.InnerHtml.AppendHtml(PageNumber.ToString());

            if (PageNumber == PageModel.Page)
                li.AddCssClass("active");
            else
            {
                //a.Attributes["href"] = Url.Action(PageAction,PageUrlValues);
                a.Attributes["href"] = "#";
            }

            PageUrlValues["page"] = PageNumber;
            foreach (var (key, value) in PageUrlValues.Select(v => (v.Key,Value: v.Value?.ToString())).Where(v => v.Value?.Length > 0))
                //if (value.ToString() is { Length: > 0 } str_value)
                    a.MergeAttribute($"data-{key}", value);

            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}
