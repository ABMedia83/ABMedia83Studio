using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32.Items
{
    /// <summary>
    /// Record discribes a Item to be used
    /// </summary>
    public sealed class BasicItem: Item
    {
        //FIeld 
        object? myvalue;
        public BasicItem()
        {
            // Do Nothing 
        }
        public BasicItem(string _name)
        {
            Name = _name;
        }
        public BasicItem(string _name, object _value)
        {
            Name = _name;
            Value = _value;
        }

       
        public object? Value
        {
            get => myvalue;
            set { myvalue = value; OnPropertyChanged("Value"); }
        }


        public override string ToString()
        {
            return Name!;
        }

    }
}
