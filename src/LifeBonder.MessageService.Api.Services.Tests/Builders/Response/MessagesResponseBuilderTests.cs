using FluentAssertions;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class MessagesResponseBuilderTests
    {
        [Fact]
        public void GetResult_ValidResponseReturned()
        {
            //Arrange
            var message = new List<Message>() { new Message() { Link = "", MessageTypeId = 1, RecepientId = 2, SecurityCode = "ABCD", SentOn = DateTime.Now, Text = "Hi", UserId = 1 } };

            var expected = new MessagesResponse() { Message = message };

            //Act

            var builder = new MessagesResponseBuilder(message);

            var result = builder.GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
