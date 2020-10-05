using LifeBonder.MessageService.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class MessagesResponseBuilder
    {
        private readonly List<Message> _messages;

        private readonly MessagesResponse _response;

        public MessagesResponseBuilder(List<Message> messages)
        {
            _messages = messages;
            _response = new MessagesResponse();
        }

        public MessagesResponse GetResult()
        {
            _response.Message = _messages;
            return _response;
        }
    }
}
