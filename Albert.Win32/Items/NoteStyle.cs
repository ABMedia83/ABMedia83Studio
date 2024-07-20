

namespace Albert.Win32.Items;

/// <summary>
/// Class is designed to Style the notes 
/// </summary>
public class NoteStyle: Item 
{
    SolidColorBrush? backgroundcolor, foregroundcolor;

    public NoteStyle()
    {
        Background = HexBrush("#ffffff")!;
        TextBrush = HexBrush("#000000")!;
    }

    public NoteStyle(string? _foreground, string? _background)
    {
        Background = HexBrush(_background!);
        TextBrush = HexBrush(_foreground!);
    }
    public NoteStyle(string? _name, string? _foreground, string? _background)
    {
        Name = _name!;
        Background = HexBrush(_background!);
        TextBrush = HexBrush(_foreground!);
    }

    public NoteStyle(Color _foreground , Color _background)
    {
        Background = new SolidColorBrush(_background!);
        TextBrush = new SolidColorBrush(_foreground!);
    }
    public SolidColorBrush? Background
    {
        get => backgroundcolor;
        set { backgroundcolor = value; OnPropertyChanged("Backgound"); }
    }
    /// <summary>
    /// Gets or set the Color of the Text 
    /// </summary>
    public SolidColorBrush? TextBrush
    {
        get => foregroundcolor;
        set { foregroundcolor = value; OnPropertyChanged("Foreground"); }
    }
}

