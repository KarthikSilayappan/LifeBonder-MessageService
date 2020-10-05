
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public interface IContactResponseBuilderFactory
    {
        void PopulateContact(List<UserContact> userContacts);
        ContactResponseBuilder CreateBuilder();
    }
}
