
using System;
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.DataAccess.Models
{
    public class UserContact
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactImageLink { get; set; }
        public int MessageTypeId { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool Sent { get; set; }
    }
}
