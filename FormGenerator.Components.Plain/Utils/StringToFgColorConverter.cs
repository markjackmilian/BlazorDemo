using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using FormGenerator.Models;

namespace FormGenerator.Utils
{
    public class StringToFgColorConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(
                context,
                sourceType);
        }

        public override object ConvertFrom(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            string stringValue = value as string;

            if (stringValue != null)
            {
                return new FgColor(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(
            ITypeDescriptorContext context,
            Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)) return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) && value is FgColor)
            {
                FgColor obj = value as FgColor;

                ConstructorInfo ctor = typeof(FgColor).GetConstructor(
                    new Type[]
                    {
                        typeof(string)
                    });

                if (ctor != null)
                {
                    return new InstanceDescriptor(
                        ctor,
                        new object[]
                        {
                            obj.Value
                        });
                }
            }

            return base.ConvertTo(
                context,
                culture,
                value,
                destinationType);
        }
    }
}
