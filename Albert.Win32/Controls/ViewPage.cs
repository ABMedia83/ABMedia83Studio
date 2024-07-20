
namespace Albert.Win32.Controls
{
    /// <summary>
    /// A special Page designed to deal with MVVM 
    /// </summary>
    public class ViewPage: Page, IAddCommand
    {
        public ViewPage()
        {
            //Do nothing for now 
        }

        /// <summary>
        /// An ovveride method designed to be used when the View has multiple Consturctor's
        /// </summary>
        public virtual void Init()
        {
            // Do nothing for now ment to call with the Constructor's your create 
        }

        #region Method from IAddCommand 

        /// <summary>
        /// Quick way to add a Coomamand to the control
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }

        #endregion

        #region SendMessage Override Method's 
        /// <summary>
        /// Send a simple message to the ViewMdoel
        /// </summary>
        /// <param name="_str"></param>
        public virtual void SendMessage(string _str)
        {
            // Do nothing for now 
        }
        /// <summary>
        /// Method is desgned to Log and send a Message to the View Model
        /// </summary>
        /// <param name="_str"></param>
        public virtual void LogAndSendMessage(string _str)
        {
            // Do nothing for now 
        }
        /// <summary>
        /// Method designed to send a File has been open Method to the Applcation 
        /// </summary>
        /// <param name="_info"></param>
        public virtual void OpenMessage(FileInfo _info)
        {
            // Do nothing for now 
        }
        /// <summary>
        /// Method designed to send a Save Message to the Application 
        /// </summary>
        /// <param name="_info"></param>
        public virtual void SaveMessage(FileInfo _info)
        {
            // Do nothing for now 
        }

        #endregion

        #region Import and Export Settings Method 
        /// <summary>
        /// Event Executes on ExportSettins Method 
        /// </summary>
        public event SettingsEventHandler? OnExportSettings;
        /// <summary>
        /// Event Exectutes on ImportSeettings method 
        /// </summary>
        public event SettingsEventHandler? OnImoortSettings;
        /// <summary>
        /// Method Export any Settings you havee for this Control 
        /// </summary>
        /// <param name="_str"></param>
        public void ExportSettings(string? _str)
        {
            //Run the OnExportSettings Event 
            OnExportSettings!.Invoke(_str!);
        }


        /// <summary>
        /// Method Imports any settings you have for this control 
        /// </summary>
        /// <param name="_str"></param>
        public void ImportSettings(string? _str)
        {
            if (Exists(_str))
            {
                OnImoortSettings!.Invoke(_str);
            }
        }

        #endregion

        
        public Frame? Frame { get; set; }


        
    }
}
