using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Models
{
    public class MessagesResponse
    {
        public IEnumerable<Message> Message { get; set; }
    }
}
