

namespace Albert;

/// <summary>
/// Delegae is designed to handle a simple Message
/// </summary>
/// <param name="message"></param>
public delegate void LogEventHandler(string? message);



/// <summary>
/// Default Interface for a ViewModel for MVVM
/// </summary>
public interface IViewModel
{
    /// <summary>
    /// Event to Display the Message 
    /// </summary>
    event LogEventHandler OnLog;
    /// <summary>
    /// Method used to call displaying the message 
    /// </summary>
    /// <param name="_msg"></param>
    void Message(string _msg, bool _isAddedToLog);


    /// <summary>
    /// Get or set a list of Messages sored in the Application 
    /// </summary>
   public ModelList<LogRecord> Logs { get; set; }
    /// <summary>
    /// Get's or Sets the amount of data you want the log to have
    /// </summary>
    public int LogCount { get; }
}
