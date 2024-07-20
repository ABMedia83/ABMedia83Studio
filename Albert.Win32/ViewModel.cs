

namespace Albert.Win32;

/// <summary>
/// Bas ViewModel for WPF Applications 
/// </summary>
public abstract class ViewModel : Notify, IViewModel
{
    #region Field's 

    TabControl? tab;
    Frame? frame;
    ModelList<LogRecord> logs = new ModelList<LogRecord>();
    ModelList<FileRecord> files = new ModelList<FileRecord>();
    string? title;
    //int logCount = logs; 
    WindowState winState; 
    




    #endregion




    #region Log and File 

  
    /// <summary>
    /// A special event that fire's when you send a Message to the Application 
    /// </summary>
    public event LogEventHandler? OnLog;

    /// <summary>
    /// Method is designed to display a Custom Method with the ONLog Event 
    /// </summary>
    /// <param name="_message"></param>
    /// <param name="_isLogged"></param>
    public void Message(string _message, bool _isLogged)
    {
        if(_isLogged == true)
        {
            if (Logs != null)
                Logs.Add(new LogRecord(_message));
        }
        else if(_isLogged == false)
        {
            //Do nothing 
        }

        //Invoke Event OnLog
        OnLog!.Invoke(_message);
    }


    /// <summary>
    /// Get or set Log Record's 
    /// </summary>
    public ModelList<LogRecord> Logs
    {
        get => logs;
        set { logs = value; OnPropertyChanged("Logs"); }
    }
    /// <summary>
    /// Get or set Files worked on
    /// </summary>
    public ModelList<FileRecord> Files
    {
        get => files;
        set { files = value; OnPropertyChanged("Files"); }
    }

    public int LogCount => logs.Count;



    #endregion

    #region Method's 
    /// <summary>
    /// Method allows the ViewModel to run other .exe on the system 
    /// </summary>
    /// <param name="exeFile">File path of the .exe file</param>
    public void RunExeFile(string exeFile)
    {
        Process p = new Process();
        p.StartInfo.FileName = exeFile;
        p.Start();
    }

    /// <summary>
    /// Method is used to quickly navigate the Frame Property 
    /// </summary>
    /// <param name="_page"></param>
    public void NavigateFrame(object _page)
    {
        if (Frame != null)
            Frame.Navigate(_page);
    }





    #endregion



    #region Public Properties 
    /// <summary>
    /// Get of set the Default Frmae 
    /// </summary>
    public Frame? Frame
    {
        get => frame;
        set { frame = value; OnPropertyChanged("Frame"); }
    }
    /// <summary>
    /// Get's or set the Default TabControl 
    /// </summary>
    public TabControl? Tab
    {
        get => tab;
        set { tab = value; OnPropertyChanged("VMTab"); }
    }

    public WindowState WindowState
    {
        get => winState;
        set { winState = value; OnPropertyChanged("WindowState"); }
    }

    /// <summary>
    /// Get or set the Title of the Application 
    /// </summary>
    public string? Title
    {
        get => title;
        set { title = value; OnPropertyChanged("Title"); }
    }









  
  

    #endregion


}
