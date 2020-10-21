using System;
using System.Collections.Generic;
using FormGenerator.Form.Components.Plain;

namespace FormGenerator.Form.Components.Bootstrap
{
    public class BootstrapInputCheckbox : FgInputCheckbox
    {
        public BootstrapInputCheckbox()
        {
            ContainerCss = "custom-control custom-checkbox line-height-checkbox";
            AdditionalAttributes = new Dictionary<string, object>()
            {
                {
                    "class",
                    "custom-control-input"
                }
            };
            LabelCss = "custom-control-label";
        }
    }
}
