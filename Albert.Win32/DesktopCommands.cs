
namespace Albert.Win32
{
	/// <summary>
	/// A list of Commands used for Desktop Applications 
	/// </summary>
	public static class DesktopCommands
	{
		private static readonly RoutedUICommand clear,loginfo, import,runconsole, export, newproject, about, saveas, quit, zoomin, zoomout,snips;

        static DesktopCommands()
        {
            clear = CreateCommand("Clear", typeof(DesktopCommands), Key.C, ModifierKeys.Alt, "Alt+C");

            loginfo = CreateCommand("LogInfo", typeof(DesktopCommands), Key.L, ModifierKeys.Control, "Ctrl+L");

            import = CreateCommand("Import", typeof(DesktopCommands), Key.I, ModifierKeys.Control, "Ctrl+I");

            runconsole = CreateCommand("RunConsole", typeof(DesktopCommands), Key.D, ModifierKeys.Control, "Ctrl+D");


            //Export Comand 
            export = CreateCommand("Export", typeof(DesktopCommands), Key.E, ModifierKeys.Control, "Ctrl+E");
            //StartView Command
            newproject = CreateCommand("New Project", typeof(DesktopCommands), Key.N, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+N");


			//About Command
			about = new RoutedUICommand("About", "About", typeof(DesktopCommands));
			about.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt, "Alt+A"));

			//SaveAs Command 
			saveas = new RoutedUICommand("SaveAs", "SaveAs", typeof(DesktopCommands));
			saveas.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift, "Ctrl+Shift+S"));

            //Quit Commmand
            quit = CreateCommand("Quit", typeof(DesktopCommands), Key.Q, ModifierKeys.Control, "Ctrl+Q");

			zoomin = new RoutedUICommand("ZoomIn", "ZoomIn", typeof(DesktopCommands));
			zoomin.InputGestures.Add(new KeyGesture(Key.OemPlus, ModifierKeys.Control, "Ctrl+"));

			zoomout = new RoutedUICommand("ZoomOut", "ZoomOut", typeof(DesktopCommands));
			zoomout.InputGestures.Add(new KeyGesture(Key.OemMinus, ModifierKeys.Control, "Ctrl-"));

			
			//Snip Command
			snips = new RoutedUICommand("Snips", "Snips", typeof(DesktopCommands));
			snips.InputGestures.Add(new KeyGesture(Key.Space, ModifierKeys.Control));

			
		
			
		}
        /// <summary>
        /// Method to Speed up Creating RoutedUICommand 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_cmdType"></param>
        /// <param name="_mainKey"></param>
        /// <param name="_modifierKey"></param>
        /// <param name="_cmdDisplay"></param>
        /// <returns>RoutedUICommand</returns>
        public static RoutedUICommand CreateCommand(string _name, Type _cmdType, Key _mainKey, ModifierKeys _modifierKey,string _cmdDisplay)
        {
            var cmd = new RoutedUICommand(_name, _name, _cmdType);
            cmd.InputGestures.Add(new KeyGesture(_mainKey, _modifierKey, _cmdDisplay));
            return cmd;
        }

        /// <summary>
        /// Get the Clear Command
        /// </summary>
        public static RoutedUICommand Clear => clear;
     

        /// <summary>
        /// Get the LogInfo Command
        /// </summary>
        public static RoutedUICommand LogInfo => loginfo;
        /// <summary>
        /// Get the Import Command
        /// </summary>
        public static RoutedUICommand Import => import;
        /// <summary>
        /// Get the RunConsole Command
        /// </summary>
        public static RoutedUICommand RunConsole => runconsole;
        /// <summary>
        /// Get the Export Command
        /// </summary>
        public static RoutedUICommand Export => export;
        /// <summary>
        /// Get the snips command
        /// </summary>
        public static RoutedUICommand Snips => snips;

        /// <summary>
        /// Get the StartView Commands
        /// </summary>
        public static RoutedUICommand NewProject => newproject;
		

 

        public static RoutedUICommand About => about;
        /// <summary>
        /// Get the Save As Command
        /// </summary>
        public static RoutedUICommand SaveAs => saveas;
        /// <summary>
        /// Get the Quit Command 
        /// </summary>
        public static RoutedUICommand Quit => quit;

        public static RoutedUICommand ZoomIn => zoomin;

        public static RoutedUICommand ZoomOut => zoomout;



    }
}
