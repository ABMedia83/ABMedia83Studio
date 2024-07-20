using System;
using System.Windows.Media;

namespace Albert.Win32.Items
{
    /// <summary>
    /// Class disigned to store Notes 
    /// </summary>
    public class NoteItem: Item 
    {
        string? notes;
        FontFamily? fontfamily;
        double fontsize;
        Color backgroundcolor, foregroundcolor;

        public NoteItem()
        {
            
        }

        public string? Notes
        {
            get => notes;
            set { notes = value; OnPropertyChanged("Notes"); }
        }
        public FontFamily? FontFamily
        {
            get => fontfamily;
            set { fontfamily = value; OnPropertyChanged("FontFamily"); }
        }
        public double FontSize
        {
            get => fontsize;
            set { fontsize = value; OnPropertyChanged("FontSize"); }
        }
        public Color BackgroundColor 
        {
            get => backgroundcolor;
            set { backgroundcolor = value; OnPropertyChanged("BackgoundColor"); }
        }
        /// <summary>
        /// Gets or set the Color of the Text 
        /// </summary>
        public Color ForegroundColor
        {
            get => foregroundcolor;
            set { foregroundcolor = value; OnPropertyChanged("ForegroundColor"); }
        }
    }
}
