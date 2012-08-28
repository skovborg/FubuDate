using System.Collections.Generic;
using System.Globalization;
using FubuDate.Localization;
using FubuLocalization;
using FubuLocalization.Basic;
using FubuValidation.StructureMap;
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

            For<ILocalizationDataProvider>()
                .Singleton()
                .Use(x =>
                {
                    var cache = new ThreadSafeLocaleCache(new CultureInfo("nb-no"), new Dictionary<LocalizationKey, string>());
                    var provider = new LocalizationProvider(cache, x.GetInstance<ILocalizationMissingHandler>());
                    return provider;
                });
            this.FubuValidation();
        }
    }
}