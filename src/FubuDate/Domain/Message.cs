using System;

namespace FubuDate.Domain
{
    public class Message
    {
        public string Id { get; set; }
        public string ToId { get; set; }
        public string FromId { get; set; }
        public string Body { get; set; }
        public DateTime Sent { get; set; }
    }
}