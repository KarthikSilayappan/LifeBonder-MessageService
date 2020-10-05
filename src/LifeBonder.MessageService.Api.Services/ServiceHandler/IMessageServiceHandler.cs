
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Request;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.ServiceHandler
{
    public interface IMessageServiceHandler
    {
        public SendMessageRequestBuilder InitializeSendMessageRequestBuilder(SendMessageRequest request);
        MessagesResponse InitializeMessagesResponseBuilder(List<UserMessage> userMessages);

        ContactResponse InitializeContactResponseBuilder(List<UserContact> userContacts);
    }
}
