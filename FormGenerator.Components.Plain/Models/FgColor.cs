using System;
using System.ComponentModel;
using FormGenerator.Utils;

namespace FormGenerator.Models
{
    [TypeConverter(typeof(StringToFgColorConverter))]
    public class FgColor
    {
        public string Value { get; private set; }

        public FgColor(string value)
        {
            this.Value = value;
        }
    }
}
