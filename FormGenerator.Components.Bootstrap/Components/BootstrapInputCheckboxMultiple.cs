using System;
using System.Collections.Generic;
using FormGenerator.Core;
using FormGenerator.Form.Components.Plain;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Form.Components.Bootstrap
{
    public class BootstrapInputCheckboxMultiple<TValue> : InputCheckboxMultipleWithChildren<TValue>, IRenderChildren
    {
        public BootstrapInputCheckboxMultiple()
        {
            this.AdditionalAttributes = new Dictionary<string, object>()
            {
                {
                    "class",
                    "form-control"
                }
            };
        }

        public new static void RenderChildren(
            RenderTreeBuilder builder,
            int index,
            object dataContext,
            string fieldIdentifier)
        {
            RenderChildren(
                builder,
                index,
                dataContext,
                fieldIdentifier,
                typeof(BootstrapInputCheckbox));
        }
    }
}
