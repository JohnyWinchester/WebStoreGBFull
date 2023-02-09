using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebStoreGB.TagHelpers
{
    [HtmlTargetElement(Attributes = AttributeName)]
    public class ActiveRoute : TagHelper
    {
        private const string AttributeName = "ws-is-active-route";
        private const string IgnoreAction = "ws-ignore-action";

        [HtmlAttributeName("ws-is-active-route-active")]
        public string ActiveCssClass { get; set; } = "active";

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        //[HtmlAttributeName("href")]
        //public string Href { get; set; } 

        [HtmlAttributeName("asp-all-route-data" ,DictionaryAttributePrefix = "asp-route-")]
        public Dictionary<string, string> RouteValues { get; set; }
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //TagHelperOutput - это олицетворение <a asp-controller="Home" asp-action="ContactUs">Контакты</a>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var is_ignore_action = output.Attributes.RemoveAll("ws-ignore-action");

            if (IsActive(is_ignore_action))
                MakeActive(output);
            output.Attributes.RemoveAll(AttributeName); // удаляем из разметки аттрибуты
        }

        private bool IsActive(bool IgnoreAction)
        {
            var route_values = ViewContext.RouteData.Values;

            var route_controller = route_values["controller"]?.ToString();
            var route_action = route_values["action"]?.ToString();

            //if (string.IsNullOrEmpty(Action) && !string.Equals(Action, route_action))
            //    return false;

            if (!IgnoreAction && Action is { Length: > 0 } action  && !string.Equals(action, route_action))
                return false;

            if(Controller is { Length: > 0} controller && !string.Equals(controller,route_controller)) 
                return false;

            foreach(var (key, value) in RouteValues)
            {
                if(!route_values.ContainsKey(key) || route_values[key].ToString() != value) 
                    return false;
            }

            return true;
        }
        private void MakeActive(TagHelperOutput output) 
        {
            var class_attribue = output.Attributes.FirstOrDefault(x => x.Name == "class");

            if (class_attribue is null)
                output.Attributes.Add("class", ActiveCssClass);
            else
            {
                if (class_attribue.Value?.ToString()?.Contains(ActiveCssClass) ?? false) return;
                output.Attributes.SetAttribute("class", $"{class_attribue.Value} {ActiveCssClass}");
            }
        }
    }
}
