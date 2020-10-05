using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.Models;
using LifeBonder.MessageService.Api.Services.Builders.Response;
using System;
using System.Collections.Generic;
using Xunit;

namespace LifeBonder.MessageService.Api.Services.Tests.Builders.Response
{
    public class ContactResponseBuilderFactoryTests
    {
        [Fact]
        public void CreateBuilder_ValidResponseReturend()
        {
            //Arrange
            DateTime date = DateTime.Now;

            var userContacts = new List<UserContact>() {
                new UserContact()
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
                        }
                };

            var contactsBuilderFactory = new ContactResponseBuilderFactory();

            contactsBuilderFactory.PopulateContact(userContacts);

            var contacts = new List<Contact>() { new Contact() { LastMessage = date, Sent = true, Message = "Hi", MessageTypeId = 1, UserId = 2, UserImageLink = "", UserName = "Karthik" } };

            var expected = new ContactResponseBuilder(contacts).GetResult();

            //Act

            var result = contactsBuilderFactory.CreateBuilder().GetResult();

            //Assert
            result.Should().BeEquivalentTo(expected);

        }
    }
}
