using System;
using System.Collections.Generic;
using FormGenerator.Core;
using Microsoft.AspNetCore.Components;

namespace FormGenerator.Form.Components.Plain
{
    public class InputCheckboxMultipleComponent<T> : FgInputBase<T>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        List<FgInputCheckboxComponent> Checkboxes = new List<FgInputCheckboxComponent>();

        protected override bool TryParseValueFromString(
            string value,
            out T result,
            out string validationErrorMessage)
                    => throw new NotImplementedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");

        internal void RegisterCheckbox(FgInputCheckboxComponent checkbox)
        {
            Checkboxes.Add(checkbox);

            StateHasChanged();
        }
    }
}
