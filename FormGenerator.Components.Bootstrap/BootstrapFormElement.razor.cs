using System;
using System.Collections.Generic;
using FormGenerator.Core;

namespace FormGenerator.Form
{
    public class BootstrapFormElementComponent<TFormElement> : FormElementBase<TFormElement>
    {
        public BootstrapFormElementComponent()
        {
            DefaultFieldClasses = new List<string>()
            {
                "form-control"
            };
            CssClasses = new List<string>()
            {
                "form-group"
            };
        }
    }
}
