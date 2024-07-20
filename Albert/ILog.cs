

namespace Albert;



/// <summary>
/// Interface is designed to set up a Log System
/// </summary>
public interface ILog
{    
    event LogEventHandler OnLog;
    void Message (string _message,bool _isLogged);
    ModelList<LogRecord> Logs { get; set; }
}
