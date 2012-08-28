using System.Collections.Generic;
using FubuDate.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace FubuDate.Configuration.Conventions
{
    public class RavenSessionConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph
                .Actions()
                .Each(x => x.AddBefore(Wrapper.For<RavenSessionBehavior>()));
        }
    }
}