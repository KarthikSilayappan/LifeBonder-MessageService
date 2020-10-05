using System.Threading.Tasks;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Models.Request;
using LifeBonder.MessageService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeBonder.MessageService.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class MessageController : Controller
    {

        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("contacts")]
        public async Task<ActionResult<ContactResponse>> GetContactDetails([FromQuery]int userId)
        {
            var result = "";
            return Ok(result);
        }

        [HttpGet("messages")]
        public async Task<ActionResult<MessagesResponse>> GetMessages([FromBody]MessagesRequest request)
        {
            var result = await _messageService.GetMessages(request);

            return Ok(result);
        }

        [HttpPost("sendmessage")]
        public async Task<ActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            var result =await _messageService.SendMessage(request);

            return Ok(result);
        }
    }
}
