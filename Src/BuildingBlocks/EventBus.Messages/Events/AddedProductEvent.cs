using System;
namespace EventBus.Messages.Events
{
    public class AddedProductEvent : BaseEvent
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }

    }
}

