using System;
using FormGenerator.Core;
using FormGenerator.Form;

namespace FormGenerator.Settings.Bootstrap
{
    public class FgBootstrapFormOptions : IFormGeneratorOptions
    {
        public Type FormElementComponent { get; set; }

        public FgBootstrapFormOptions()
        {
            FormElementComponent = typeof(BootstrapFormElement<>);
        }
    }
}
