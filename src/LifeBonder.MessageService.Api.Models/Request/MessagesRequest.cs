
using System.ComponentModel.DataAnnotations;

namespace LifeBonder.MessageService.Api.Models.Request
{
    public class MessagesRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RecepientId { get; set; }
        [Required]
        public string SecurityCode { get; set; }
    }
}
