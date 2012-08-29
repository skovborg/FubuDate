
using System;
using System.Linq;
using FubuMVC.Core.Continuations;
using Raven.Client;

namespace FubuDate.Endpoints.Message
{
    public class IndexEndpoint
    {
        private readonly IDocumentSession _session;

        public IndexEndpoint(IDocumentSession session)
        {
            _session = session;
        }

        public MessageIndexViewModel Get(MessageIndexRequest request)
        {
            var user = _session.Query<Domain.User>().First(x => x.Username == request.ToUser);
            
            return new MessageIndexViewModel{ToUser = user.Username};
            
        }

        public FubuContinuation Post(NewMessageInput request)
        {
            var to = _session.Query<Domain.User>().First();
            var from = _session.Query<Domain.User>().First(x => x.Username == request.ToUser);
            
            var message = new Domain.Message
                              {
                                  Body = request.Message,
                                  ToId = to.Id,
                                  FromId = from.Id,
                                  Sent = DateTime.Now
                              };

            _session.Store(message);

            return FubuContinuation.RedirectTo(new NewMessageInput());
        }
    }
}