using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MyChat.Handlers;
using MyChat.Models;

namespace MyChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatEventHandler _chatEventHandler;

        public ChatHub(IChatEventHandler chatEventHandler)
        {
            _chatEventHandler = chatEventHandler;
        }

        public async Task SendMessage(string sender, string message)
        {
            await Clients.All.SendAsync("chat", sender, message);

            _chatEventHandler.Publish(new ChatMessageReceivedEvent
            {
                Message = message
            });
        }
    }
}