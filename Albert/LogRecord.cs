

namespace Albert
{
    /// <summary>
    /// Record is designed to Log information from an Application
    /// </summary>
    public record LogRecord
    {
        string? time, date;

        public LogRecord()
        {
            DateTime dateTime = DateTime.Now;

            date = DateOnly.FromDateTime(dateTime).ToString();
            time = TimeOnly.FromDateTime(dateTime).ToString();

        }
        public LogRecord(string _msg)
        {
            Message = _msg;
            DateTime dateTime = DateTime.Now;

            date = DateOnly.FromDateTime(dateTime).ToString();
            time= TimeOnly.FromDateTime(dateTime).ToString();

        }
        /// <summary>
        /// Get the Messge that is Logged
        /// </summary>
        public string? Message { get; init; }


        /// <summary>
        /// Get the Date 
        /// </summary>
        public string? Date => date;
        /// <summary>
        /// Get the Time of Day
        /// </summary>
        public string? Time => time;

        public override string ToString()
        {

            return $"Message: {Message}\nDate: {Date}\nTime {Time}";

        }

    }
}
