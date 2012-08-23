using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;

namespace FubuDate.Configuration
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<IDocumentStore>().Singleton().Use(x =>
            {
                var store = new DocumentStore();
                store.ConnectionStringName = "RavenDB";
                store.Initialize();

                return store;
            });


            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });


            For<IDocumentSession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x =>
                {
                    var store = x.GetInstance<IDocumentStore>();
                    return store.OpenSession();
                });
        }
    }
}