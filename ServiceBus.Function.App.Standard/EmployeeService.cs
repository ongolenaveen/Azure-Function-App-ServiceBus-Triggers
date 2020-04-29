using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceBus.Function.App.Contracts;
using ServiceBus.Function.App.Utilities;
using System.Threading.Tasks;

namespace ServiceBus.Function.App.Services
{
    // Employee Service
    public class EmployeeService : IMessageService
    {
        private readonly ILogger<EmployeeService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        public EmployeeService(ILogger<EmployeeService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Process Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Task</returns>
        public async Task Process(string message)
        {
            message.ThrowIfIsNullOrWhitespace(nameof(message));

            var employee = JsonConvert.DeserializeObject<Employee>(message);
            await Task.CompletedTask;
        }
    }
}
