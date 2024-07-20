

namespace Albert.Win32.Controls
{
    /// <summary>
    /// A special TextBox designed for writing documents 
    /// </summary>
    public class WriterBox: TextBox, IAddCommand  
    {
        public WriterBox()
        {
            

            SpellCheck.IsEnabled = true;

            
            
            //Make sure spell check shows up no matter what the context menu
            ContextMenuOpening += (sender, e) =>
            {
                if (ContextMenu != null)
                {
                    int caretIndex, cmdIndex;

                    //Set your Ints
                    cmdIndex = 0;
                    caretIndex = CaretIndex;


                    //Create a spelling error 
                    SpellingError spellingError;
                    spellingError = GetSpellingError(caretIndex);

                    if (spellingError != null)
                    {
                        foreach (string str in spellingError.Suggestions)
                        {
                            var mi = new MenuItem();
                            mi.Header = str;
                            mi.FontWeight = FontWeights.Bold;
                            mi.Command = EditingCommands.CorrectSpellingError;
                            mi.CommandParameter = str;
                            mi.CommandTarget = this;
                            ContextMenu.Items.Insert(cmdIndex, mi);
                            cmdIndex++;
                        }
                        Separator separatorMenuItem1 = new Separator();
                        ContextMenu.Items.Insert(cmdIndex, separatorMenuItem1);
                        cmdIndex++;
                        MenuItem ignoreAllMI = new MenuItem();
                        ignoreAllMI.Header = "Ignore All";
                        ignoreAllMI.Command = EditingCommands.IgnoreSpellingError;
                        ignoreAllMI.CommandTarget = this;
                        ContextMenu.Items.Insert(cmdIndex, ignoreAllMI);
                        cmdIndex++;
                        var separatorMenuItem2 = new Separator();
                        ContextMenu.Items.Insert(cmdIndex, separatorMenuItem2);
                    }
                }


            
            };
        }


        /// <summary>
        /// Simplafy Addiing Commands 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }

        public void AddText(string _str)
        {
            this.Text += _str;
        }
        /// <summary>
        /// Get or set the Current File that ahas ben saved 
        /// </summary>
        public string? CurrentFile { get; set; }

    }
}
