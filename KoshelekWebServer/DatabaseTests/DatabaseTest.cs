using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Interfaces;
using Moq;

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

        public void WhenUserSendingMessage_AndMessageIsCorrect_ThenMessageShouldBeSaving()
        {
            // Arrange.
            Message message = new Message() { Id = 1, MessageText = "Hello!", Date = new DateTime(2024, 05, 24, 2, 34, 12) };

            // Act.
            _messageSenderService.Setup(x => x.SaveMessageServiceAsync(message)).ReturnsAsync(message);
            // Assert.
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