namespace EventBus.Messages.Events
{
    public class AddLogDataEvent : BaseEvent
    {
     
        public string ControllerName { get;  set; }
        public string ActionName { get;  set; }
        public string LogLevel { get;  set; }
        public string Message { get;  set; }
    }
}

