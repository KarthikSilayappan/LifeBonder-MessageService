
using LifeBonder.MessageService.Api.DataAccess.Repository;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Models.Request;
using LifeBonder.MessageService.Api.Services.ServiceHandler;
using System.Threading.Tasks;

namespace LifeBonder.MessageService.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageServiceHandler _messageServiceHandler;

        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageServiceHandler messageServiceHandler,IMessageRepository messageRepository)
        {
            _messageServiceHandler = messageServiceHandler;
            _messageRepository = messageRepository;
        }

        public async Task<bool> SendMessage(SendMessageRequest request)
        {
            var message= _messageServiceHandler.InitializeSendMessageRequestBuilder(request).GetResult();

            return await _messageRepository.SendMessage(message);
        }

        public async Task<MessagesResponse> GetMessages(MessagesRequest request)
        {
            var messages = await _messageRepository.GetMessages(request.UserId, request.RecepientId);

            return _messageServiceHandler.InitializeMessagesResponseBuilder(messages);
        }

        public async Task<ContactResponse> GetContacts(int userId)
        {
            var contacts = await _messageRepository.GetContacts(userId);

            return _messageServiceHandler.InitializeContactResponseBuilder(contacts);
        }
    }
}
