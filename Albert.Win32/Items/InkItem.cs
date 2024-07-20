using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Albert.Win32.MediaConvert;
namespace Albert.Win32.Items
{
    /// <summary>
    /// Item designed to changed the theme of INk or Draw Canvas
    /// </summary>
    public sealed class InkItem: Item
    {
        
        Color background, foreground;

        
        public InkItem()
        {
            ForegroundColor = HexColor("#ffffff");
            BackgroundColor = HexColor("#000000");
        }

        public InkItem(string _Name, Color _foreground, Color _background)
        {
            Name = _Name;
            BackgroundColor = _background;
            ForegroundColor = _foreground;
        }


        public Color BackgroundColor
        {
            get => background;
            set { background = value; OnPropertyChanged("BackgroundColor"); }
        }
        public Color ForegroundColor
        {
            get => foreground;
            set { foreground = value; OnPropertyChanged("ForegroundColor"); }
        }



    }
}
