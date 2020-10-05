
using DataAccessModel=LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System;

namespace LifeBonder.MessageService.Api.Services.Builders.Request
{
    public class SendMessageRequestBuilder
    {
        private readonly SendMessageRequest _sendMessageRequest;

        private readonly DataAccessModel.UserMessage _userMessage;

        public SendMessageRequestBuilder(SendMessageRequest request)
        {
            _sendMessageRequest = request;
            _userMessage = new DataAccessModel.UserMessage();
        }

        public DataAccessModel.UserMessage GetResult()
        {
            _userMessage.UserId = _sendMessageRequest.UserId;
            _userMessage.RecepientId = _sendMessageRequest.RecepientId;
            _userMessage.SecurityCode = _sendMessageRequest.SecurityCode;
            _userMessage.Link = _sendMessageRequest.Link;
            _userMessage.Message = _sendMessageRequest.Message;
            _userMessage.MessageTypeId = _sendMessageRequest.MessageTypeId;
            _userMessage.SentOn = _sendMessageRequest.SentOn;
            return _userMessage;
        }
    }
}
