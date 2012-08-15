using FubuMVC.Core;
using FubuMVC.Spark;

namespace FubuDate
{
    public class FubuDateRegistry : FubuRegistry
    {
        public FubuDateRegistry()
        {
            //IncludeDiagnostics(true);

            Applies
                .ToThisAssembly();

            Actions
                .IncludeClassesSuffixedWithController();

            Routes
                .IgnoreControllerNamespaceEntirely();

            Import<SparkEngine>();

            Views
                .TryToAttachWithDefaultConventions();
        }
    }
}
