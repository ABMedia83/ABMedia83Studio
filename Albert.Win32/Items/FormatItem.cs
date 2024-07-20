using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32.Items
{
    /// <summary>
    /// Item is designed to Represent a Image SIze messured in pixel's 
    /// </summary>
    public class FormatItem: Item 
    {
        //Field's 
        double width, height;
 
        public FormatItem()
        {
            Width = 1920;
            Height = 1080;
        }

        public FormatItem(double _width, double _height)
        {
            Width = _width;
            Height = _height;

        }
        public FormatItem(string _name, double _width, double _height)
        {
            Name = _name;
            Width = _width;
            Height = _height;

        }

        public FormatItem(double _square)
        {
            Width = _square;
            Height = _square;
        }

        public FormatItem(string _name, double _square)
        {
            Name = _name;
            Width = _square;
            Height = _square;
        }



        /// <summary>
        /// Get the Width you want 
        /// </summary>
        public double Width
        {
            get => width;
            set { width = value; OnPropertyChanged("Width"); }
        }
        /// <summary>
        /// Get the Height you want
        /// </summary>
        public double Height
        {
            get => height;
            set { height = value; OnPropertyChanged("Height"); }
        }

        public override string ToString()
        {
            return $"{Name} ({Width}px  x  {Height}px)";
        }


        public void Deconstruct(out double _width, out double _height)
        {
            _width = Width;
            _height = Height;
        }
   
    }
}
