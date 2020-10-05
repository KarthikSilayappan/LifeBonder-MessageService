
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using System;
using System.Collections.Generic;

namespace LifeBonder.MessageService.Api.Services.Builders.Response
{
    public class ContactBuilder
    {
        private readonly Contact _response;

        private readonly int _userId;

        private readonly string _userName;
        private readonly int _messageTypeId;
        private readonly string _message;
        private readonly string _userImageLink;

        private readonly DateTime _lastMessage;
        private readonly bool _sent;


        public ContactBuilder(UserContact userContact)
        {
            _userId = userContact.ContactId;
            _userName = userContact.ContactName;
            _message = userContact.Text;
            _messageTypeId = userContact.MessageTypeId;
            _lastMessage = userContact.LastUpdated;
            _sent = userContact.Sent;
            _userImageLink = userContact.ContactImageLink;
            _response = new Contact();
        }

        public Contact GetResult()
        {
            _response.LastMessage = _lastMessage;
            _response.Message = _message;
            _response.MessageTypeId = _messageTypeId;
            _response.Sent = _sent;
            _response.UserId = _userId;
            _response.UserImageLink = _userImageLink;
            _response.UserName = _userName;
            return _response;
        }
    }
}
