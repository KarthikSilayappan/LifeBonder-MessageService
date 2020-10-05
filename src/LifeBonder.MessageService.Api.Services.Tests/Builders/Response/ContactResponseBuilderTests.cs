using FluentAssertions;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class ContactResponseBuilderTests
    {
        [Fact]
        public void GetResult_ValidResponseReturned()
        {
            //Arrange
            var contacts = new List<Contact>() { new Contact()
                {
                    UserId=2,
                    UserImageLink="",
                    UserName="Karthik",
                    LastMessage=DateTime.Now,
                    Message="Hi",
                    MessageTypeId=1,
                    Sent=true
                }
            };

            var expected = new ContactResponse() { Contacts = contacts };

            //Act
            var builder = new ContactResponseBuilder(contacts);

            var result = builder.GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
