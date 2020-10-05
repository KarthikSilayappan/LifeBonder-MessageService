using LifeBonder.MessageService.Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeBonder.MessageService.Api.DataAccess.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDbContext _messageDbContext;
        public MessageRepository(MessageDbContext context)
        {
            _messageDbContext = context;
        }

        public async Task<bool> SendMessage(UserMessage userMessage)
        {
            await _messageDbContext.UserMessages.AddAsync(userMessage);

            _messageDbContext.SaveChanges();

            return true;
        }

        public async Task<List<UserMessage>> GetMessages(int userId,int recepientId)
        {
            var messages =  _messageDbContext.UserMessages
                                                .Where(message => message.UserId == userId && message.RecepientId == recepientId)
                                                .Select(message=>message).ToList();
            return messages;
        }

        public async Task<List<UserContact>> GetContacts(int userId)
        {
            var contacts = _messageDbContext.UserContacts
                                            .Where(usercontact => usercontact.UserId == userId)
                                            .Select(contact => contact).ToList();

            return contacts;
        }
    }
}
