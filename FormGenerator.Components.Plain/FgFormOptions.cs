using System;
using FormGenerator.Core;
using FormGenerator.Form;

namespace FormGenerator.Settings
{
    public class FgFormOptions : IFormGeneratorOptions
    {
        public Type FormElementComponent { get; set; }

        public FgFormOptions()
        {
            FormElementComponent = typeof(FormElement<>);
        }
    }
}
