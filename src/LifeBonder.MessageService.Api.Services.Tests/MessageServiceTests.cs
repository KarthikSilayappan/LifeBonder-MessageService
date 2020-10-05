using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.DataAccess.Repository;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Models.Request;
using LifeBonder.MessageService.Api.Services.Builders.Request;
using LifeBonder.MessageService.Api.Services.ServiceHandler;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests
{
    public class MessageServiceTests
    {
        [Fact]
        public void SendMessage_WhenValidRequestPassed_ValidResponseReturened()
        {
            //Arrange
            var messageRepositoryMock = new Mock<IMessageRepository>();
            var messageServiceHandlerMock = new Mock<IMessageServiceHandler>();

            var messageRequest = new SendMessageRequest()
            {
                Link = "",
                Message = "Hi",
                MessageTypeId = 1,
                RecepientId = 2,
                SecurityCode = "ABCD",
                SentOn = DateTime.Now,
                UserId = 1
            };

            var sendMessageRequestBilder = new SendMessageRequestBuilder(messageRequest);

            messageServiceHandlerMock.Setup(s => s.InitializeSendMessageRequestBuilder(It.IsAny<SendMessageRequest>()))
                                     .Returns(sendMessageRequestBilder);

            messageRepositoryMock.Setup(s => s.SendMessage(It.IsAny<UserMessage>())).ReturnsAsync(true);

            var messageService = new MessageService(messageServiceHandlerMock.Object, messageRepositoryMock.Object);

            //Act
            var result = messageService.SendMessage(messageRequest).Result;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void GetMessages_WhenValidDataPassed_ValidResponseReturned()
        {
            //Arrange
            var messageRepositoryMock = new Mock<IMessageRepository>();
            var messageServiceHandlerMock = new Mock<IMessageServiceHandler>();

            var userMessages = new List<UserMessage>()
            {
                new UserMessage()
                    {
                        Id = 1,
                        Link = "",
                        Message = "Hi",
                        MessageTypeId = 1,
                        RecepientId = 2,
                        SecurityCode = "ABCD",
                        SentOn = DateTime.Now,
                        UserId = 1
                    }
            };

            var messageReequest = new MessagesRequest() { RecepientId = 2, UserId = 1, SecurityCode = "ABCD" };

            var expected = ExpectMessagesResponse();

            messageRepositoryMock.Setup(s => s.GetMessages(It.IsAny<Int32>(),It.IsAny<Int32>()))
                                              .ReturnsAsync(userMessages);

            messageServiceHandlerMock.Setup(s => s.InitializeMessagesResponseBuilder(It.IsAny<List<UserMessage>>()))
                                     .Returns(expected);

            //Arrange
            var messageService = new MessageService(messageServiceHandlerMock.Object, messageRepositoryMock.Object);

            var result = messageService.GetMessages(messageReequest);

            //Assert
            result.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void GetContacts_WhenValidDataPassed_ValidResponseRetruned()
        {
            //Arrange
            var messageRepositoryMock = new Mock<IMessageRepository>();
            var messageServiceHandlerMock = new Mock<IMessageServiceHandler>();

            var userContact = new List<UserContact>() { new UserContact()
                                            {
                                                ContactName="Karthik",
                                                ContactId=2,
                                                ContactImageLink="",
                                                LastUpdated=DateTime.Now,
                                                Link="",
                                                MessageTypeId=1,
                                                Sent=true,
                                                Text="Hi",
                                                UserId=1
                                            } 
                                        };

            var expected = ExpectedContactResponse();

            messageRepositoryMock.Setup(s => s.GetContacts(It.IsAny<Int32>()))
                                              .ReturnsAsync(userContact);

            messageServiceHandlerMock.Setup(s => s.InitializeContactResponseBuilder(It.IsAny<List<UserContact>>()))
                                                .Returns(expected);


            //Arrange
            var messageService = new MessageService(messageServiceHandlerMock.Object, messageRepositoryMock.Object);

            var result = messageService.GetContacts(1).Result;

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        private MessagesResponse ExpectMessagesResponse()
        {
            return new MessagesResponse()
            {
                Message=new List<Message>()
                {
                   new Message()
                   {
                       MessageTypeId=1,
                       Link="",
                       RecepientId=2,
                       UserId=1,
                       SecurityCode="ABCD",
                       SentOn=DateTime.Now,
                       Text="Hi"
                   }
                }
            };
        }

        private ContactResponse ExpectedContactResponse()
        {
            return new ContactResponse()
            {
                Contacts=new List<Contact>()
                {
                    new Contact()
                    {
                        UserId=1,
                        UserImageLink="",
                        UserName="Karthik",
                        LastMessage=DateTime.Now,
                        Message="Hi",
                        MessageTypeId=1,
                        Sent=true
                    }
                }
            };
        }
    }
}
