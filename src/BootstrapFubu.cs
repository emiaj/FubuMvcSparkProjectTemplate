using System.Web.Routing;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using $safeprojectname$.Endpoints.Home;
using $safeprojectname$.Services;
using $safeprojectname$.UI;
using StructureMap.Configuration.DSL;

namespace $safeprojectname$
{
    // Using a separate class for bootstrapping makes it much easier to reuse your application 
    // in testing scenarios with either SelfHost or OWIN/Katana hosting
    public class MyApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            // This is bootstrapping an application with all default FubuMVC conventions and
            // policies pulling actions from only this assembly for classes suffixed with
            // "Endpoint" or "Endpoints"
            //return FubuApplication.DefaultPolicies().StructureMap<MyStructureMapRegistry>();



            // Fancier way if you want to specify your own policies:
            // return FubuApplication.For<MyFubuMvcPolicies>().StructureMap(new Container());


            // Here's an example of using StructureMap specific registration with a StructureMap Registry.  
             return FubuApplication.For<MyFubuMvcPolicies>().StructureMap<MyStructureMapRegistry>();
        }
    }

    public class MyStructureMapRegistry : Registry
    {
        public MyStructureMapRegistry()
        {
            // StructureMap registration here
        }
    }

    public class MyFubuMvcPolicies : FubuRegistry
    {
        public MyFubuMvcPolicies() {
	        //The default policy is to treat all classes suffixed with "endpoint" as action sources
			//Actions.FindBy(source => source.IncludeTypesNamed(s => s.EndsWith("Endpoint")));
			
			Routes
				.IgnoreMethodSuffix("Command")
				.IgnoreControllerNamesEntirely()
				.IgnoreControllerNamespaceEntirely()
				.HomeIs<IndexInput>() //The default policy is that HomeEndpoint.Index() is the action that corresponds to the default page.
				.ConstrainToHttpMethod(x => !x.Method.Name.EndsWith("Command"), "GET")
				.ConstrainToHttpMethod(x => x.Method.Name.EndsWith("Command"), "POST");

			Import<AppHtmlConventions>();

			Services(x => x.SetServiceIfNone<IMembershipService, InMemoryMembershipService>());
        }
    }
}