
using System;
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.Models
{
    public class Contact
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserImageLink { get; set; }
        public string Message { get; set; }
        public int MessageTypeId { get; set; }
        public DateTime LastMessage { get; set; }
        public bool Sent { get; set; }
    }
}
