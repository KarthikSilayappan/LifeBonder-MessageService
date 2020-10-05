
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class MessageBuilder
    {

        private int _userId;

        private int _recepientId;

        private string _securityCode;

        private string _text;

        private int _messageTypeId;

        private string _link;

        private DateTime _sentOn;
        private readonly Message _response;

        public MessageBuilder(UserMessage message)
        {
            _userId = message.UserId;
            _recepientId = message.RecepientId;
            _securityCode = message.SecurityCode;
            _text = message.Message;
            _messageTypeId = message.MessageTypeId;
            _link = message.Link;
            _sentOn = message.SentOn;
            _response = new Message();
        }

        public Message GetResult()
        {
            _response.Link = _link;
            _response.MessageTypeId = _messageTypeId;
            _response.RecepientId = _recepientId;
            _response.SecurityCode = _securityCode;
            _response.SentOn = _sentOn;
            _response.Text = _text;
            _response.UserId = _userId;
            return _response;
        }
    }
}
