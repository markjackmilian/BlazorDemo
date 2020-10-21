using System;
using System.Linq.Expressions;
using FormGenerator.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Form.Components.Plain
{
    public class InputCheckboxMultipleWithChildren<TValue> : InputCheckboxMultiple<TValue>, IRenderChildrenSwapable
    {
        public static void RenderChildren(
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
                typeof(FgInputCheckbox));
        }

        protected static void RenderChildren(
            RenderTreeBuilder builder,
            int index,
            object dataContext,
            string fieldIdentifier,
            Type typeOfChildToRender)
        {
            builder.AddAttribute(
                index++,
                nameof(ChildContent),
                new RenderFragment(_builder =>
                {
                    var values = FormElementReference<ValueReferences>.GetValue(
                        dataContext,
                        fieldIdentifier);
                    foreach (var val in values)
                    {
                        var _index = 0;

                        _builder.OpenComponent(
                            _index++,
                            typeOfChildToRender);

                        _builder.AddAttribute(
                            _index++,
                            nameof(FgInputCheckbox.Value),
                            val.Value);

                        _builder.AddAttribute(
                            _index++,
                            nameof(ValueChanged),
                            Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck(
                                EventCallback.Factory.Create<bool>(
                                    dataContext,
                                    EventCallback.Factory.CreateInferred(
                                        val.Value,
                                        __value => val.Value = __value, val.Value))));

                        var constant = Expression.Constant(
                            val,
                            val.GetType());
                        var exp = Expression.Property(
                            constant,
                            nameof(ValueReference<string, bool>.Value));
                        var lamb = Expression.Lambda<Func<bool>>(exp);
                        _builder.AddAttribute(
                            _index++,
                            nameof(InputBase<bool>.ValueExpression),
                            lamb);
                        _builder.AddAttribute(
                            _index++,
                            nameof(FgInputCheckbox.Label),
                            val.Key);

                        _builder.CloseComponent();
                    }
                }));
        }
    }
}
