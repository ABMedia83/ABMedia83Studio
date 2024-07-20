

namespace Albert.Win32.Controls;

/// <summary>
/// A basic Usercontrol WIth a Title 
/// </summary>
public class TitleControl : ContentControl, IAddCommand
{
    public static readonly DependencyProperty TitleProperty = DP("Title", typeof(string), typeof(TitleControl));
    public static readonly DependencyProperty TextAlignmentProperty = DP("TextAlignment", typeof(TextAlignment), typeof(TitleControl));



    public TitleControl()
    {
        //ReDraw the Control 
        DefaultStyleKey = typeof(TitleControl);
    }

    /// <summary>
    /// Get or set the Title 
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    /// <summary>
    /// Get or set the Text Alignmeent of the Title 
    /// </summary>
    public TextAlignment TextAlignment
    {
        get=> (TextAlignment)GetValue(TextAlignmentProperty);
        set => SetValue(TextAlignmentProperty, value);
    }

    /// <summary>
    /// A quick method for adding a Command 
    /// </summary>
    /// <param name="_command"></param>
    /// <param name="_method"></param>
    public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
    {
        CommandBindings.Add(new CommandBinding(_command, _method));
    }
}
