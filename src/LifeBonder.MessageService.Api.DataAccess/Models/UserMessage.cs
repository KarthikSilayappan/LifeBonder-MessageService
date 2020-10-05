using System;
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.DataAccess.Models
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecepientId { get; set; }
        public string SecurityCode { get; set; }
        public string Message { get; set; }
        public int MessageTypeId { get; set; }
        public string Link { get; set; }
        public DateTime SentOn { get; set; }
    }
}
