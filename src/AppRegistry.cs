using FubuMVC.Core;
using FubuMVC.Spark;
using $safeprojectname$.Handlers.Home;
using $safeprojectname$.Services;
using $safeprojectname$.UI;

namespace $safeprojectname$
{
    public class AppRegistry : FubuRegistry
    {
        public AppRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            Actions.IncludeTypes(x => x.Name.EndsWith("Handler"));

            Routes.IgnoreMethodSuffix("Command");
            Routes.IgnoreControllerNamesEntirely();
            Routes.IgnoreControllerNamespaceEntirely();
            Routes.HomeIs<IndexInput>();
            Routes.ConstrainToHttpMethod(x => !x.Method.Name.EndsWith("Command"), "GET");
            Routes.ConstrainToHttpMethod(x => x.Method.Name.EndsWith("Command"), "POST");

            Views.TryToAttachWithDefaultConventions();

            this.UseSpark();

            HtmlConvention<AppHtmlConventions>();


            Services(x => x.SetServiceIfNone<IMembershipService, InMemoryMembershipService>());
        }
    }
}