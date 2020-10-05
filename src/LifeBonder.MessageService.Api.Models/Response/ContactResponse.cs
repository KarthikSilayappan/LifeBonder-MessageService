using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.Models
{
    public class ContactResponse
    {
       public IEnumerable<Contact> Contacts { get; set; }
    }
}
