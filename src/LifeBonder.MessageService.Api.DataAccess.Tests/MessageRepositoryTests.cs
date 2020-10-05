using FluentAssertions;
using LifeBonder.MessageService.Api.DataAccess.Config;
using LifeBonder.MessageService.Api.DataAccess.Models;
using LifeBonder.MessageService.Api.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Xunit;

namespace LifeBonder.MessageService.Api.DataAccess.Tests
{
    public class MessageRepositoryTests
    {
        [Fact]
        public void SendMessage_WhenValidDataPassed_AddedtoDb()
        {
            //Arrange
            var mockdb = CreateMessageContextWithInMemoryTestDb();
            var userMessage = new UserMessage() 
                                          { 
                                            Id = 1,
                                            Link = "",
                                            Message = "Hi",
                                            MessageTypeId = 1,
                                            RecepientId = 2,
                                            SecurityCode = "ABCD",
                                            SentOn = DateTime.Now,
                                            UserId = 1 
                                          };
            var messageRepo = new MessageRepository(mockdb);

            //Act
            var messageAdded = messageRepo.SendMessage(userMessage);
            var result = mockdb.UserMessages.FirstOrDefaultAsync<UserMessage>(b => b.RecepientId.Equals(userMessage.RecepientId)).Result;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetMessages_GivenUserIdNotExistsInDb_NullReturned()
        {
            //Arrange
            var mockdb = CreateMessageContextWithInMemoryTestDb();
            
            var messageRepo = new MessageRepository(mockdb);

            //Act
            var result = messageRepo.GetMessages(1,2).Result.Count;

            //Assert
            Assert.Equal(0,result);
        }

        [Fact]
        public void GetContacts_GivenUserIdNotExistsInDb_NullReturned()
        {
            //Arrange
            var mockdb = CreateMessageContextWithInMemoryTestDb();

            var messageRepo = new MessageRepository(mockdb);

            //Act
            var result = messageRepo.GetContacts(1).Result.Count;

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetMessage_GivenUserIdExistsInDb_ValueReturned()
        {
            //Arrange
            var mockdb = CreateMessageContextWithInMemoryTestDb();

            var expected = new UserMessage()
            {
                Id = 1,
                Link = "",
                Message = "Hi",
                MessageTypeId = 1,
                RecepientId = 2,
                SecurityCode = "ABCD",
                SentOn = DateTime.Now,
                UserId = 1
            };

            var messageRepo = new MessageRepository(mockdb);

            AddMessageToContext(mockdb, expected);

            //Act
            var result = messageRepo.GetMessages(1,2).Result;

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetContacts_GivenUserIdExistsInDb_ValueReturned()
        {
            //Arrange
            var mockdb = CreateMessageContextWithInMemoryTestDb();

            var expected = new UserContact()
                                        {
                                            ContactId=2,
                                            ContactImageLink="",
                                            ContactName="Karthik",
                                            Id=1,
                                            LastUpdated=DateTime.Now,
                                            Link="",
                                            MessageTypeId=1,
                                            Sent=true,
                                            Text="Hi",
                                            UserId=1
                                        };

            
            var messageRepo = new MessageRepository(mockdb);

            AddContactToContext(mockdb,expected);

            //Act
            var result = messageRepo.GetContacts(1).Result;

            //Assert
            result.Should().BeEquivalentTo(expected);
        }


        private MessageDbContext CreateMessageContextWithInMemoryTestDb()
        {
            var options = new DbContextOptionsBuilder<MessageDbContext>().UseInMemoryDatabase(databaseName:"InMemoryDatabase")
                                            .Options;
            var sqlSettings = new DatabaseSettings();
            var sqlOptions = Options.Create(sqlSettings);
            return new MessageDbContext(sqlOptions, options);
        }

        private void AddMessageToContext(MessageDbContext messageDbContext, UserMessage userMessage)
        {
            messageDbContext.UserMessages.Add(userMessage);
            messageDbContext.SaveChanges();
        }

        private void AddContactToContext(MessageDbContext messageDbContext,UserContact userContact)
        {
            messageDbContext.UserContacts.Add(userContact);
            messageDbContext.SaveChanges();
        }
    }
}
