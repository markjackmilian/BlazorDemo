using System;
using FormGenerator.Core;
using Microsoft.AspNetCore.Components;

namespace FormGenerator.Form.Components.Plain
{
    public class FgInputCheckboxComponent : FgInputBase<bool>, IDisposable
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string LabelCss { get; set; }

        [Parameter]
        public string ContainerCss { get; set; }

        protected override bool TryParseValueFromString(
            string value,
            out bool result,
            out string validationErrorMessage) => throw new NotImplementedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
