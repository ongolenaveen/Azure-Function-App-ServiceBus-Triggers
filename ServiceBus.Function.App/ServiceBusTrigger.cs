using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceBus.Function.App.Contracts;
using ServiceBus.Function.App.Utilities;
using System.Threading.Tasks;

namespace ServiceBus.Function.App
{
    /// <summary>
    /// Service Bus Trigger
    /// </summary>
    public class ServiceBusTrigger
    {
        private readonly ILogger<ServiceBusTrigger> _logger;
        private readonly IMessageService _messageService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageService">Message Service</param>
        /// <param name="logger">Logger</param>
        public ServiceBusTrigger(IMessageService messageService, ILogger<ServiceBusTrigger> logger )
        {
            _logger = logger;
            _messageService = messageService;
        }

        /// <summary>
        /// Service Bus Trigger
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageId">Message Id</param>
        [FunctionName("OnEmployeeAddition")]
        public async Task Run([ServiceBusTrigger("employees", "MathematicsDepartment", Connection = "ServiceBusConnection")]string message, string messageId)
        {
            message.ThrowIfIsNullOrWhitespace(nameof(message));
            messageId.ThrowIfIsNullOrWhitespace(nameof(messageId));

            // Process the Message
            await _messageService.Process(message);
        }
    }
}
