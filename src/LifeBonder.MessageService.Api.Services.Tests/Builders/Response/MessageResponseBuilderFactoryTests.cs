using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class MessageResponseBuilderFactoryTests
    {
        [Fact]
        public void CreateBuilder_ValidResponseReturned()
        {
            //Arrange

            DateTime date = DateTime.Now;

            var userMessages = new List<UserMessage>() { new UserMessage() {    Id = 1,
                MessageTypeId = 1,
                RecepientId = 2,
                Link = "",
                Message = "Hi",
                SecurityCode = "ABCD",
                SentOn = date,
                UserId = 1 } };

            var messageBuilderFactory = new MessageResponseBuilderFactory();

            messageBuilderFactory.PopulateMessage(userMessages);

            var message = new List<Message>() { new Message() { Link = "", MessageTypeId = 1, RecepientId = 2, SecurityCode = "ABCD", SentOn = date, Text = "Hi", UserId = 1 } };

            var expected = new MessagesResponseBuilder(message).GetResult();

            //Act
            var result = messageBuilderFactory.CreateBuilder().GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
