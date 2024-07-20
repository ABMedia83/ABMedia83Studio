using System;
using Albert;
using static Albert.Win32.MediaConvert;
using System.Windows.Media;

namespace Albert.Win32.Items
{
    public sealed class BrushItem : Item
    {
        Brush? brush;
        /// <summary>
        /// Default Constructor: Color is Black v
        /// </summary>
        public BrushItem()
        {
            Brush = new SolidColorBrush(Colors.Black)!;
        }
        /// <summary>
        /// Constuct Brush with Hexidecimal 
        /// </summary>
        /// <param name="_hex">Hexidecimal</param>
        public BrushItem(string? _hex)
        {
            Brush = HexBrush(_hex!);
        }

        /// <summary>
        /// Constuctor for Color Type 
        /// </summary>
        /// <param name="_color"></param>
        public BrushItem(Color _color)
        {
            Brush = new SolidColorBrush(_color);
           
        }
        /// <summary>
        /// Constructor for the Solid Color Brush Type 
        /// </summary>
        /// <param name="_brush"></param>
        public BrushItem(Brush? _brush)
        {
            Brush = _brush!;
        }
        public BrushItem(string? _name,Brush _brush)
        {
            Name = _name!;
            Brush = _brush;
        }





        /// <summary>
        /// Get or set Brush to be used 
        /// </summary>
        public Brush? Brush
        {
            get => brush; 
            set { brush = value; OnPropertyChanged("Brush"); }

        }
    }
    
}
