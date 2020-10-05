using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Request;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.ServiceHandler
{
    public class MessageServiceHandler : IMessageServiceHandler
    {
        private readonly IMessageResponseBuilderFactory _messageResponseBuilderFactory;

        private readonly IContactResponseBuilderFactory _contactResponseBuilderFactory;
        public MessageServiceHandler(IMessageResponseBuilderFactory messageResponseBuilderFactory,
                                    IContactResponseBuilderFactory contactResponseBuilderFactory)
        {
            _contactResponseBuilderFactory = contactResponseBuilderFactory;
            _messageResponseBuilderFactory = messageResponseBuilderFactory;
        }

        public SendMessageRequestBuilder InitializeSendMessageRequestBuilder(SendMessageRequest request)
        {
            return new SendMessageRequestBuilder(request);
        }

        public MessagesResponse InitializeMessagesResponseBuilder(List<UserMessage> userMessages)
        {
            _messageResponseBuilderFactory.PopulateMessage(userMessages);

            return _messageResponseBuilderFactory.CreateBuilder().GetResult();
        }

        public ContactResponse InitializeContactResponseBuilder(List<UserContact> userContacts)
        {
            _contactResponseBuilderFactory.PopulateContact(userContacts);

            return _contactResponseBuilderFactory.CreateBuilder().GetResult();
        }
    }
}
