
using LifeBonder.MessageService.Api.DataAccess.Models;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public interface IMessageResponseBuilderFactory
    {
       public void PopulateMessage(List<UserMessage> userMessages);

       public MessagesResponseBuilder CreateBuilder();
    }
}
