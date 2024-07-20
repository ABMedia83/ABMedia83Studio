using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Albert.Win32.Items
{
    public sealed class FontItem: Item
    {
        public FontItem(string _name)
        {
            Name = _name;
            FontFamily = new FontFamily(_name);
        }

        
        public FontFamily FontFamily {get;init;}

        public override string ToString()
        {
            return Name!;
        }
    }
}
