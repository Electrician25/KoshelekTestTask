using Castle.Core.Logging;
using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Interfaces;
using KoshelekWebServer.Services;
using MessageSenderClient.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTests
{
    public class DatabaseTest
    {
        private readonly Mock<ICreatorMessageService> _messageCreatorService;
        private readonly Mock<IMessageByDateService> _messageByDateService;
        private readonly Mock<IMessageSenderService> _messageSenderService;
        private readonly Mock<IMessageSenderBySocketService> _messageSenderBySocketService;

        public DatabaseTest()
        {
            _messageCreatorService = new Mock<ICreatorMessageService>();
            _messageByDateService = new Mock<IMessageByDateService>();
            _messageSenderService = new Mock<IMessageSenderService>();
            _messageSenderBySocketService = new Mock<IMessageSenderBySocketService>();
        }

        [Fact]
        public void WhenUserSendingMessage_AndMessageIsCorrect_ThenMessageShouldBeSaving()
        {
            // Arrange.
            Message message = new Message() { Id = 1, MessageText = "Hello!", Date = new DateTime(2024, 05, 24, 2, 34, 12) };
            _messageSenderService.Setup(x => x.SaveMessageServiceAsync(message)).ReturnsAsync(message);
            _messageCreatorService.Setup(x => x.GetMessage(message)).Returns($"MESSAGE={message.MessageText} DATE={message.Date}");
            var logger = new Mock<ILogger<MessageSenderController>>();
            var controller = new MessageSenderController(_messageSenderService.Object, _messageCreatorService.Object, logger.Object);

            // Act.
            var resultController = controller.SendMessageAsync(message).Result;

            // Assert.
            Assert.Equal(message.MessageText, resultController.MessageText);
            Assert.True(message.Equals(resultController));
        }

        public void WhenUserSendingMessage_AndMessageIsNotCorrect_ThenMessageShouldBeNotSaving()
        {
            // Arrange.
            // Act.
            // Assert.
        }

        public void WhenUserSendingMessage_AndMessageIsLonger128Chars_ThrowException()
        {
            // Arrange.
            // Act.
            // Assert.
        }

        public void WhenCreatingMessage_AndDateAndTextIsCorrect_ThenMessageIsCorrect()
        {
            // Arrange.
            // Act.
            // Assert.
        }

        public void WhenFindingDate_AndDateIsExist_ThenReturnTrue()
        {
            // Arrange.
            // Act.
            // Assert.
        }

        public void WhenFindingDate_AndDateIsNotExist_ThenReturnFalse()
        {
            // Arrange.
            // Act.
            // Assert.
        }

        public void WhenFindingDate_AndDateIsNotCorrectFormatExist_ThrowDataIsNotCorrectException()
        {
            // Arrange.
            // Act.
            // Assert.
        }
    }
}