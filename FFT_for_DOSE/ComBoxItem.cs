using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFT_For_DOSE
{
    class ComboboxItem
    {
            public ComboboxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public string Value
            {
                get;
                set;
            }

            public string Text
            {
                get;
                set;
            }

            public override string ToString()
            {
                return Text;
            }       
    }
}
