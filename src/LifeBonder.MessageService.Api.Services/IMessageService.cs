
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Models.Request;
using System.Threading.Tasks;

namespace LifeBonder.MessageService.Api.Services
{
    public interface IMessageService
    {
        Task<MessagesResponse> GetMessages(MessagesRequest request);
        Task<bool> SendMessage(SendMessageRequest request);
        Task<ContactResponse> GetContacts(int userId);
    }
}
