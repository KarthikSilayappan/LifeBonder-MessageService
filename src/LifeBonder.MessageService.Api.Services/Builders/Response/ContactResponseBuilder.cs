

using LifeBonder.MessageService.Api.Models;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class ContactResponseBuilder
    {
        private readonly ContactResponse _response;

        private readonly List<Contact> _contacts;

        public ContactResponseBuilder(List<Contact> contacts)
        {
            _contacts = contacts;
            _response = new ContactResponse();
        }

        public ContactResponse GetResult()
        {
            _response.Contacts = _contacts;
            return _response;
        }
    }
}
