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
        public void WhenUserSendingMessage_AndMessageAndDateIsNotCorrect_ThenMessageShouldBeNotCorrect()
        {
            // Arrange.
            Message firstMessage = new Message()
            {
                Id = 1,
                MessageText = "Hello!",
                Date = new DateTime(2024, 05, 24, 2, 34, 12)
            };

            Message secondMessage = new Message()
            {
                Id = 1,
                MessageText = "qergHelqerglo!",
                Date = new DateTime(2024, 05, 24, 2, 34, 12)
            };

            _messageSenderService.Setup(x
                => x.SaveMessageServiceAsync(firstMessage)).ReturnsAsync(secondMessage);

            _messageCreatorService.Setup(x
                => x.GetMessage(firstMessage)).Returns($"MESSAGE={firstMessage.MessageText} DATE={firstMessage.Date}");

            var logger = new Mock<ILogger<MessageSenderController>>();
            var controller = new MessageSenderController(_messageSenderService.Object, _messageCreatorService.Object, logger.Object);

            // Act.
            var resultController = controller.SendMessageAsync(firstMessage).Result;

            // Assert.
            Assert.True(firstMessage.Id.Equals(resultController.Id));
            Assert.False(firstMessage.MessageText.Equals(resultController.MessageText));
            Assert.False(firstMessage.Date.Equals(resultController.Date));
            Assert.False(firstMessage.Equals(resultController));
        }

        [Fact]
        public void WhenUserSendingMessage_AndMessageAndDateIsCorrect_ThenMessageShouldBeCorrect()
        {
            // Arrange.
            Message firstMessage = new Message()
            {
                Id = 1,
                MessageText = "Hello!",
                Date = new DateTime(2024, 05, 24, 2, 34, 12)
            };

            Message secondMessage = new Message()
            {
                Id = 1,
                MessageText = "Hello!",
                Date = DateTime.UtcNow
            };

            _messageSenderService.Setup(x
                => x.SaveMessageServiceAsync(firstMessage)).ReturnsAsync(secondMessage);

            _messageCreatorService.Setup(x
                => x.GetMessage(firstMessage)).Returns($"MESSAGE={firstMessage.MessageText} DATE={firstMessage.Date}");

            var logger = new Mock<ILogger<MessageSenderController>>();
            var controller = new MessageSenderController(_messageSenderService.Object, _messageCreatorService.Object, logger.Object);

            // Act.
            var resultController = controller.SendMessageAsync(firstMessage).Result;

            // Assert.
            Assert.True(firstMessage.Id.Equals(resultController.Id));
            Assert.True(firstMessage.MessageText.Equals(resultController.MessageText));
            Assert.True(firstMessage.Date.Date.Equals(resultController.Date.Date));
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
            var messages = GetMessages();
            var date = new DateTime(2024, 05, 22);

            var logger = new Mock<ILogger<MessageByDateController>>();

            _messageByDateService.Setup(x
                => x.GetMessagesByDateServiceAsync(date))
                .ReturnsAsync(messages);

            var dateController = new MessageByDateController(_messageByDateService.Object, logger.Object);

            // Act.
            var controllerResult = dateController.GetMessageByDateAsync(date);
            var resultDateCount = 0;

            foreach (var element in controllerResult.Result)
            {
                if (element.Date == date)
                    resultDateCount++;
            }

            // Assert.
            Assert.Equal(resultDateCount, 3);
        }

        [Fact]
        public void WhenFindingDate_AndDateIsNotExist_ThenReturnEmpty()
        {
            // Arrange.
            var messages = GetMessages();
            var date = new DateTime(2024, 05, 24);

            var logger = new Mock<ILogger<MessageByDateController>>();

            _messageByDateService.Setup(x
                => x.GetMessagesByDateServiceAsync(date))
                .ReturnsAsync(messages);

            var dateController = new MessageByDateController(_messageByDateService.Object, logger.Object);

            // Act.
            var controllerResult = dateController.GetMessageByDateAsync(date);
            var resultDateCount = 0;

            foreach (var element in controllerResult.Result)
            {
                if (element.Date == date)
                    resultDateCount++;
            }

            // Assert.
            Assert.Equal(resultDateCount, 0);
        }

        private Message[] GetMessages()
        {
            return new[]
            {
                new Message () { Id = 1, MessageText = "Evening John!", Date = new DateTime(2024, 05, 22) },
                new Message () { Id = 2, MessageText = "Evening Jummy...", Date = new DateTime(2024, 05, 22)},
                new Message () { Id = 3, MessageText = "Noise complaints?", Date = new DateTime(2024, 05, 22)},
                new Message () { Id = 4, MessageText = "Noise complaints...", Date = new DateTime(2024, 05, 23)}
            };
        }
    }
}