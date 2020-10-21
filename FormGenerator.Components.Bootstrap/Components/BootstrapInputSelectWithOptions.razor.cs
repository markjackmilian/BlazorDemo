using System;
using System.Collections.Generic;
using FormGenerator.Form.Components.Plain;

namespace FormGenerator.Form.Components.Bootstrap
{
    public class BootstrapInputSelectWithOptionsComponent<TValue> : InputSelectWithOptions<TValue>
    {
        public BootstrapInputSelectWithOptionsComponent()
        {
            this.AdditionalAttributes = new Dictionary<string, object>()
            {
                { "class", "custom-select" }
            };
        }
    }
}
