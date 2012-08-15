using System.Web;
using Bottles;
using FubuMVC.Core;
using StructureMap;
using FubuMVC.StructureMap;

namespace FubuDate
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            FubuApplication
                .For<FubuDateRegistry>()
                .StructureMap(() => new Container(SetupContainer))
                .Bootstrap();

            // If there is an error during bootstrapping, it will not automatically be considered
            // fatal and there will be no YSOD.  This is to help during initial debugging and 
            // troubleshooting package loading. Normally, however, you want a YSOD if there is
            // a bootstrapping failure or a package-loading failure. This next line ensures that.
            PackageRegistry.AssertNoFailures(); 
        }

        private static void SetupContainer(ConfigurationExpression x)
        {
        }
    }
}
