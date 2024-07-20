
namespace Albert.Win32.Controls
{
	/// <summary>
	/// Basic Window for doing MVVM applicatoins 
	/// </summary>
	public class ViewShell : Window, IAddCommand
	{




		public virtual void Init()
        {
			// Do nothing for now 
        }
		/// <summary>
		/// Add Command Quickly 
		/// </summary>
		/// <param name="_command">ICommand</param>
		/// <param name="_method">Event Lamba</param>
		public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
		{
			//Add Command 
			CommandBindings.Add(new CommandBinding(_command, _method));
		}

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



    }
}
