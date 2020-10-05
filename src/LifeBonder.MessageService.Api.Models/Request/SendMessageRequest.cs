using System;
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.Models
{
    public class SendMessageRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecepientId { get; set; }
        [Required]
        public string SecurityCode { get; set; }
        [Required]
        public string Message { get; set; }
        public int MessageTypeId { get; set; }
        public string Link { get; set; }
        [Required]
        public DateTime SentOn { get; set; }
    }
}
