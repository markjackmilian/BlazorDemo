using System;
using FormGenerator.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Form.Components.Plain
{
    public class InputSelectWithOptions<TValue> : InputSelect<TValue>, IRenderChildren
    {
        public static Type TypeOfChildToRender => typeof(InputSelectOption<string>);

        public static void RenderChildren(
            RenderTreeBuilder builder,
            int index,
            object dataContext,
            string fieldIdentifier)
        {
            builder.AddAttribute(
                index + 1,
                nameof(ChildContent),
                new RenderFragment(_builder =>
                {
                    if (typeof(TValue).IsEnum)
                    {
                        var values = typeof(TValue).GetEnumValues();
                        foreach (var val in values)
                        {
                            _builder.OpenComponent(
                                0,
                                TypeOfChildToRender);

                            _builder.AddAttribute(
                                1,
                                nameof(InputSelectOption<string>.Value),
                                val.ToString());
                            _builder.AddAttribute(
                                2,
                                nameof(InputSelectOption<string>.Key),
                                val.ToString());

                            _builder.CloseComponent();
                        }
                    }
                }));
        }
    }
}
