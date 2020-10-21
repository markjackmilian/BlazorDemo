using System;
using System.Diagnostics.CodeAnalysis;
using FormGenerator.Core;
using FormGenerator.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Form.Components.Plain
{
    public class InputColor : FgInputBase<FgColor>
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(
                0,
                "input");
            builder.AddMultipleAttributes(
                1,
                AdditionalAttributes);
            builder.AddAttribute(
                2,
                "type",
                "color");
            builder.AddAttribute(
                3,
                "class",
                CssClass);
            builder.AddAttribute(
                5,
                "onchange",
                EventCallback.Factory.CreateBinder<FgColor>(
                    this,
                    __value => CurrentValue = __value, CurrentValue));
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(
            string value,
            out FgColor result,
            [NotNullWhen(false)] out string validationErrorMessage)
                        => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }

}
