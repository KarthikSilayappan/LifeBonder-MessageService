
using LifeBonder.MessageService.Api.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeBonder.MessageService.Api.DataAccess.Repository
{
    public interface IMessageRepository
    {
        public Task<bool> SendMessage(UserMessage message);

        public Task<List<UserMessage>> GetMessages(int userId, int recepientId);

        Task<List<UserContact>> GetContacts(int userId);
    }
}
