
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class MessageResponseBuilderFactory:IMessageResponseBuilderFactory
    {
        private List<Message> messages=new List<Message>();
        public void PopulateMessage(List<UserMessage> userMessages)
        {
            messages = new List<Message>();
            foreach (var userMessage in userMessages)
            {
                messages.Add(new MessageBuilder(userMessage).GetResult());
            }
        }

        public MessagesResponseBuilder CreateBuilder()
        {
            return new MessagesResponseBuilder(messages);
        }
    }
}
