using DatabaseLevel.DAL.Entities;
using KoshelekWebServer.Controllers;
using KoshelekWebServer.Exceptions;
using KoshelekWebServer.Interfaces;
using KoshelekWebServer.Services;
using MessageSenderClient.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace DatabaseTests
{

    public class DatabaseTest
    {
        private readonly Mock<ICreatorMessageService> _messageCreatorService;
        private readonly Mock<IMessageByDateService> _messageByDateService;
        private readonly Mock<IMessageSenderService> _messageSenderService;

        public DatabaseTest()
        {
            _messageCreatorService = new Mock<ICreatorMessageService>();
            _messageByDateService = new Mock<IMessageByDateService>();
            _messageSenderService = new Mock<IMessageSenderService>();
        }

        [Fact]
        public void WhenUserSendingMessage_AndMessageAndDateIsCorrect_ThenMessageShouldBeCorrect()
        {
            // Arrange.
            Message message = new Message()
            {
                Id = 1,
                MessageText = "Hello!",
                Date = new DateTime(2024, 05, 24, 2, 34, 12)
            };

            _messageSenderService.Setup(x
                => x.SaveMessageServiceAsync(message)).ReturnsAsync(message);

            _messageCreatorService.Setup(x
                => x.GetMessage(message)).Returns($"MESSAGE={message.MessageText} DATE={message.Date}");

            var logger = new Mock<ILogger<MessageSenderController>>();
            var controller = new MessageSenderController(_messageSenderService.Object, _messageCreatorService.Object, logger.Object);

            // Act.
            var resultController = controller.SendMessageAsync(message).Result;

            // Assert.
            Assert.Equal(message.Id, resultController.Id);
            Assert.Equal(message.MessageText, resultController.MessageText);
            Assert.Equal(message.Date, resultController.Date);

            Assert.True(message.Equals(resultController));
        }

        [Fact]
        public void WhenCreatingMessage_AndMessageIsLonger128Chars_ThrowMessageToLargeException()
        {
            // Arrange.
            var creatorMessageLogggerMock = new Mock<ILogger<CreatorMessageService>>();

            Message message = new Message()
            {
                Id = 1,
                MessageText = "This message will be very long, " +
                "I am writing it to test the operation of the " +
                "program in accordance with the requirements of the " +
                "test task, this message must exceed 128 characters",
                Date = new(2024, 05, 25, 3, 6, 18)
            };

            _messageCreatorService.Setup(x =>
                    x.GetMessage(message)).Returns($"MESSAGE={message.MessageText} DATE={message.Date}");

            var messageCreator = new CreatorMessageService(
                creatorMessageLogggerMock.Object);

            // Act.
            Action resultMessageCreator = () => messageCreator.GetMessage(message);

            // Assert.
            Assert.Throws<MessageToLargeException>(resultMessageCreator);
        }

        [Fact]
        public void WhenCreatingMessage_AndMessageCreatingIsCorrect_ThenMessageIsCorrect()
        {
            // Arrange.
            var creatorMessageLogggerMock = new Mock<ILogger<CreatorMessageService>>();

            Message message = new Message()
            {
                Id = 1,
                MessageText = "Hello! William!",
                Date = new(2024, 05, 25, 3, 6, 18)
            };

            _messageCreatorService.Setup(x =>
                    x.GetMessage(message)).Returns($"MESSAGE={message.MessageText} DATE={message.Date}");

            var messageCreator = new CreatorMessageService(
                creatorMessageLogggerMock.Object);

            // Act.
            var resultMessageCreator = messageCreator.GetMessage(message);
            var actualMessage = "MESSAGE=Hello! William! DATE=25.05.2024 3:06:18";

            // Assert.
            Assert.Equal(resultMessageCreator.Length, 47);
            Assert.Equal(resultMessageCreator, actualMessage);
        }

        [Fact]
        public void WhenFindingDate_AndDateIsExist_ThenReturnDate()
        {
            // Arrange.
            var messages = new[]
            {
                new Message() { Id = 1, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 2, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 3, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 4, Date = new DateTime(2024, 05, 23) },
            };

            var logger = new Mock<ILogger<MessageByDateController>>();

            _messageByDateService.Setup(x
                => x.GetMessagesByDateServiceAsync(new DateTime(2024, 05, 22)))
                .ReturnsAsync(new Message[] { messages[0], messages[1], messages[2] });

            var dateController = new MessageByDateController(_messageByDateService.Object, logger.Object);

            // Act.
            var resultDate = dateController.GetMessageByDateAsync(new DateTime(2024, 05, 22));

            // Assert.
            Assert.Equal(resultDate.Result.Length, 3);
            Assert.Equal(resultDate.Result, new Message[] { messages[0], messages[1], messages[2] });
        }

        [Fact]
        public void WhenFindingDate_AndDateIsNotExist_ThenReturnEmpty()
        {
            // Arrange.
            var messages = new[]
            {
                new Message() { Id = 1, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 2, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 3, Date = new DateTime(2024, 05, 22) },
                new Message() { Id = 4, Date = new DateTime(2024, 05, 23) },
            };

            var logger = new Mock<ILogger<MessageByDateController>>();

            _messageByDateService.Setup(x
                => x.GetMessagesByDateServiceAsync(new DateTime(2024, 05, 25)))
                .ReturnsAsync(new Message[] { });

            var dateController = new MessageByDateController(_messageByDateService.Object, logger.Object);

            // Act.
            var resultDate = dateController.GetMessageByDateAsync(new DateTime(2024, 05, 25));

            // Assert.
            Assert.Equal(resultDate.Result.Length, 0);
            Assert.Equal(resultDate.Result, new Message[] { });
        }
    }
}