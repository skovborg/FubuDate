using FubuMVC.Core.Behaviors;
using Raven.Client;

namespace FubuDate.Behaviors
{
    public class RavenSessionBehavior : BasicBehavior
    {
        private readonly IDocumentSession _session;

        public RavenSessionBehavior(IDocumentSession session)
            : base(PartialBehavior.Ignored)
        {
            _session = session;
        }

        protected override void afterInsideBehavior()
        {
            try
            {
                _session.SaveChanges();
            }
            finally
            {
                _session.Dispose();
            }
        }
    }
}