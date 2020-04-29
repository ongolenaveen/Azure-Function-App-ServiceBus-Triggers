using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using ServiceBus.Function.App.Contracts;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Function.App.Services.Tests
{
    [TestFixture]
    public class EmployeeServiceTests:TestBase
    {

        private Mock<ILogger<EmployeeService>> _logger;
        private EmployeeService _sut;

        [SetUp]
        public void Setup()
        {
            _logger = _mockRepository.Create<ILogger<EmployeeService>>();
            _sut = new EmployeeService(_logger.Object);
        }

        [Test]
        public void Process_With_Null_Message_Throws_Exception()
        {
            // Arrange

            // Act
            Func<Task> act = async () => { await _sut.Process(null); };

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Process_With_Exception_While_Processing_Message_Throws_Exception()
        {
            // Arrange
            var message = _fixture.Create<string>();

            // Act
            Func<Task> act = async () => { await _sut.Process(message); };

            // Assert
            act.Should().Throw<JsonReaderException>();
        }

        [Test]
        public async Task Process_With_Valid_Request_Receives_Valid_Response()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            string message = JsonConvert.SerializeObject(employee);

            // Act
            await _sut.Process(message);

            // Assert
        }
    }
}
