using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class ContactBuilderTests
    {
        [Fact]
        public void GetResult_ValidResponseRetrned()
        {
            DateTime date = DateTime.Now;
            //Arrange
            var userContact = new UserContact()
            {
                UserId = 1,
                LastUpdated = date,
                Link = "",
                ContactImageLink = "",
                ContactId = 2,
                ContactName = "Karthik",
                MessageTypeId = 1,
                Sent = true,
                Text = "Hi"
            };

            var expected = new Contact()
            {
                UserId=2,
                UserImageLink="",
                UserName="Karthik",
                LastMessage=date,
                Sent=true,
                Message="Hi",
                MessageTypeId=1
            };

            //Act
            var builder = new ContactBuilder(userContact);

            var result = builder.GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
