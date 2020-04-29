using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ServiceBus.Function.App.Contracts;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Function.App.Tests
{
    [TestFixture]
    public class ServiceBusTriggerTests:TestBase
    {
        private Mock<ILogger<ServiceBusTrigger>> _mockLogger;
        private Mock<IMessageService> _mockMessageService;
        private ServiceBusTrigger _sut;

        [SetUp]
        public void Setup()
        {
            _mockLogger = _mockRepository.Create<ILogger<ServiceBusTrigger>>();
            _mockMessageService = _mockRepository.Create<IMessageService>();
            _sut = new ServiceBusTrigger(_mockMessageService.Object, _mockLogger.Object);
        }

        [Test]
        public void Run_With_Null_Message_Throws_Exception()
        {
            // Arrange
            var messageId = _fixture.Create<string>();

            // Act
            Func<Task> act = async () => { await _sut.Run(null, messageId); };

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Run_With_Null_MessageId_Throws_Exception()
        {
            // Arrange
            var message = _fixture.Create<string>();

            // Act
            Func<Task> act = async () => { await _sut.Run(message, null); };

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Run_With_Exception_While_Processing_Message_Throws_Exception()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var messageId = _fixture.Create<string>();

            _mockMessageService.Setup(x => x.Process(It.IsAny<string>())).Throws(new SystemException());

            // Act
            Func<Task> act = async () => { await _sut.Run(message, message); };

            // Assert
            act.Should().Throw<SystemException>();
        }

        [Test]
        public async Task Run_With_Valid_Request_Receives_Valid_Response()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var messageId = _fixture.Create<string>();

            _mockMessageService.Setup(x => x.Process(It.IsAny<string>())).Returns(Task.CompletedTask);

            // Act
            await _sut.Run(message, messageId);

            // Assert
        }
    }
}
