using FubuMVC.Core.UI;
using HtmlTags;

namespace $safeprojectname$.UI
{
    public class AppHtmlConventions : HtmlConventionRegistry
    {
        public AppHtmlConventions()
        {
            Editors.IfPropertyIs<bool>()
                .BuildBy(e => new CheckboxTag(e.Value<bool>()));

            Editors.If(x => x.Accessor.Name.Contains("Password"))
                .BuildBy(e => new TextboxTag(e.ElementId, e.StringValue()).Attr("type", "password"));
        }
    }
}