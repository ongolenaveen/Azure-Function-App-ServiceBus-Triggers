using System.Threading.Tasks;

namespace ServiceBus.Function.App.Contracts
{
    // Message Service Contracts 
    public interface IMessageService
    {
        /// <summary>
        /// Process Message
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Task</returns>
        Task Process(string message);
    }
}
