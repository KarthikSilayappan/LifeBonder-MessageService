using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using LifeBonder.MessageService.Api.Services.ServiceHandler;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.ServiceHandler
{
    public class MessageServiceHandlerTests
    {
        [Fact]
        public void InitializeSendMessageRequestBuilder_ValidDataPassed_responseReturned()
        {
            //Arrange

            var messageBuilderFactoryMock = new Mock<MessageResponseBuilderFactory>();
            var conactBuilderFactoryMock = new Mock<ContactResponseBuilderFactory>();

            DateTime dateTime = DateTime.Now;

            var sendMessageRequest = new SendMessageRequest()
            {
                Link = "",
                Message = "Hi",
                MessageTypeId = 1,
                RecepientId = 2,
                SecurityCode = "ABCD",
                SentOn = dateTime,
                UserId = 1
            };

            var expected = new UserMessage()
            {
                UserId = 1,
                Id = 0,
                Link = "",
                Message = "Hi",
                MessageTypeId = 1,
                RecepientId = 2,
                SecurityCode = "ABCD",
                SentOn = dateTime
            };

            //Arrange
            var serviceHandler = new MessageServiceHandler(messageBuilderFactoryMock.Object, conactBuilderFactoryMock.Object);

            var result = serviceHandler.InitializeSendMessageRequestBuilder(sendMessageRequest);

            //Arrange
            result.GetResult().Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void InitializeMessagesResponseBuilder_ValidDataPassed_ResponseReturned()
        {
            //Arrange

            var messageBuilderFactoryMock = new Mock<IMessageResponseBuilderFactory>();
            var conactBuilderFactoryMock = new Mock<IContactResponseBuilderFactory>();

            var expected = ExpectedMessageResponseBuilder();

            var usermessages=new List<UserMessage>(){ new UserMessage()
            {
                UserId = 1,
                Id = 0,
                Link = "",
                Message = "Hi",
                MessageTypeId = 1,
                RecepientId = 2,
                SecurityCode = "ABCD",
                SentOn = DateTime.Now
            } };

            messageBuilderFactoryMock.Setup(s => s.CreateBuilder()).Returns(expected);

            //Act
            var serviceHandler = new MessageServiceHandler(messageBuilderFactoryMock.Object, conactBuilderFactoryMock.Object);

            var result = serviceHandler.InitializeMessagesResponseBuilder(usermessages);

            //Assert
            result.Should().BeEquivalentTo(expected.GetResult());
        }

        [Fact]
        public void InitializeContactsResponseBuilder_ValidDataPassed_ResponseReturned()
        {
            //Arrange

            var messageBuilderFactoryMock = new Mock<IMessageResponseBuilderFactory>();
            var conactBuilderFactoryMock = new Mock<IContactResponseBuilderFactory>();

            var expected = ExpectedContactResponseBuilder();

            var usercontacts = new List<UserContact>(){ new UserContact()
            {
                UserId = 1,
                Id = 0,
                Link = "",
                LastUpdated=DateTime.Now,
                ContactImageLink="",
                ContactId=2,
                ContactName="Karthik",
                MessageTypeId=1,
                Sent=true,
                Text="Hi"
            } };

            conactBuilderFactoryMock.Setup(s => s.CreateBuilder()).Returns(expected);

            //Act
            var serviceHandler = new MessageServiceHandler(messageBuilderFactoryMock.Object, conactBuilderFactoryMock.Object);

            var result = serviceHandler.InitializeContactResponseBuilder(usercontacts);

            //Assert
            result.Should().BeEquivalentTo(expected.GetResult());
        }


        private MessagesResponseBuilder ExpectedMessageResponseBuilder()
        {
            return new MessagesResponseBuilder(new List<Message>() {
                new Message()
                {
                    UserId=1,
                    Link="",
                    MessageTypeId=1,
                    RecepientId=2,
                    SecurityCode="ABCD",
                    SentOn=DateTime.Now,
                    Text="Hi"
                }
            });
        }

        private ContactResponseBuilder ExpectedContactResponseBuilder()
        {
            return new ContactResponseBuilder(new List<Contact>() 
            { 
                new Contact()
                {
                    LastMessage=DateTime.Now,
                    UserImageLink="",
                    UserId=2,
                    UserName="Karthik",
                    Message="Hi",
                    MessageTypeId=1,
                    Sent=true
                }
            });
        }
    }
}
