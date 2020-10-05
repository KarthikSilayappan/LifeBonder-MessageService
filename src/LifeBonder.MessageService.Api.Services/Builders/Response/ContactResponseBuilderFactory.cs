
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class ContactResponseBuilderFactory: IContactResponseBuilderFactory
    {
        private List<Contact> contacts;
        public void PopulateContact(List<UserContact> userContacts)
        {
            contacts = new List<Contact>();
            foreach (var contact in userContacts)
            {
                contacts.Add(new ContactBuilder(contact).GetResult());
            }
        }

        public ContactResponseBuilder CreateBuilder()
        {
            return new ContactResponseBuilder(contacts);
        }
    }
}
