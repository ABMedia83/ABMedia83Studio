

namespace Albert.Win32.Items;

/// <summary>
/// Record disigned to stor a 5 Color Theme 
/// </summary>
public sealed class ThemeItem : Item
{
    //Field's 
    int count;
    Color primary, secondary, accent, accent2, accent3;
    public ThemeItem()
    {
        if (Name is null || Name is "")
        {
            //Create A Default Name 
            Name = $"Theme{count++}";
        }
    }




    public Color PrimaryColor
    {
        get => primary;
        set { primary = value; OnPropertyChanged("PrimaryColor"); }
    }
    public Color SecondaryColor
    {
        get => secondary;
        set { secondary = value; OnPropertyChanged("SecondaryColor"); }
    }
    public Color AccentOne
    {
        get => accent;
        set { accent = value; OnPropertyChanged("AccentOne"); }
    }
    public Color AccentTwo
    {
        get => accent2;
        set { accent2 = value; OnPropertyChanged("AccentTwo"); }
    }
    public Color AccentThree
    {
        get => accent3;
        set { accent3 = value; OnPropertyChanged("AccentThree"); }
    }

}
