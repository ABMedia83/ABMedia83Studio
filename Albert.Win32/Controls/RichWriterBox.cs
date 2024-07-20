

namespace Albert.Win32.Controls
{
    /// <summary>
    /// A special RichTextBox designed to do Spell Checking by default in the ContextMenu
    /// </summary>
    public class RichWriterBox: RichTextBox
    {
        public RichWriterBox()
        {
            SpellCheck.IsEnabled = true;



            //Make sure spell check shows up no matter what the context menu
            ContextMenuOpening += (sender, e) =>
            {
                if (ContextMenu != null)
                {
                    int  cmdIndex;
                    TextPointer caretIndex;

                    //Set your Ints
                    cmdIndex = 0;
                    caretIndex = CaretPosition;
                    


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
    }
}
