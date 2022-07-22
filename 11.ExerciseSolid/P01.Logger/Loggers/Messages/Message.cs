namespace P01.Logger
{ 
    public class Message : IMessage
    {
        private string dateTime;
        private string messageText;

        public Message(string dateTime, string messageText, ReportLevel level)
        {
            this.DateTime = dateTime;
            this.MessageText = messageText;
            this.Level = level;
        }

        public string DateTime { get; }
        public string MessageText { get; }
        public ReportLevel Level { get; }

        
    }
}
