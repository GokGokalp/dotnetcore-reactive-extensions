using System;
using MyChat.Models;

namespace MyChat.Handlers
{
    public interface IChatEventHandler
    {
        void Publish(ChatMessageReceivedEvent eventMessage);
        void Subscribe(string subscriberName, Action<ChatMessageReceivedEvent> action);
        void Subscribe(string subscriberName, Func<ChatMessageReceivedEvent, bool> predicate, Action<ChatMessageReceivedEvent> action);
    }
}