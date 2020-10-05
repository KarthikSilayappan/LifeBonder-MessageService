using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class MessageBuilderTests
    {
        [Fact]
        public void GetResult_ValidResponseReturned()
        {
            //Arrange
            DateTime date = DateTime.Now;

            var usermessage = new UserMessage()
            {
                Id = 1,
                MessageTypeId = 1,
                RecepientId = 2,
                Link = "",
                Message = "Hi",
                SecurityCode = "ABCD",
                SentOn = date,
                UserId = 1
            };

            var message = new Message()
            {
                Link="",
                MessageTypeId=1,
                RecepientId=2,
                SecurityCode="ABCD",
                SentOn=date,
                Text="Hi",
                UserId=1
            };

            var builder = new MessageBuilder(usermessage);

            //Arrange
            var result = builder.GetResult();

            //Assert
            result.Should().BeEquivalentTo(message);
        }
    }
}
