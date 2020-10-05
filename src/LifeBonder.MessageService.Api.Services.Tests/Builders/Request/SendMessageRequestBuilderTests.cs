using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Request;
using System;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Request
{
    public class SendMessageRequestBuilderTests
    {
        [Fact]
        public void GetResult_ValidResponseReturned()
        {
            //Arrange
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

            //Act
            var builder = new SendMessageRequestBuilder(sendMessageRequest);

            var result = builder.GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
