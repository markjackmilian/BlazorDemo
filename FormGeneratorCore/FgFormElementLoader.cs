using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Core
{
    public class FgFormElementLoader<TValue> : OwningComponentBase
    {
        [Inject]
        private IFormGeneratorOptions Options { get; set; }

        [Parameter]
        public FormElementReference<TValue> ValueReference { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var elementType = Options.FormElementComponent;

            if (elementType.IsGenericTypeDefinition)
            {
                Type[] typeArgs = { typeof(TValue) };
                elementType = elementType.MakeGenericType(typeArgs);
            }

            builder.OpenComponent(
                0,
                elementType);

            builder.AddAttribute(
                1,
                nameof(FormElementBase<TValue>.Value),
                ValueReference.Value);

            builder.AddAttribute(
                2,
                nameof(FormElementBase<TValue>.ValueChanged),
                ValueReference.ValueChanged);

            if (ValueReference.ValueExpression == null)
            {
                var constant = Expression.Constant(
                    ValueReference,
                    ValueReference.GetType());

                var exp = Expression.Property(
                    constant,
                    nameof(ValueReference.Value));

                var lamb = Expression.Lambda<Func<TValue>>(exp);

                builder.AddAttribute(
                    4,
                    nameof(FormElementBase<TValue>.ValueExpression),
                    lamb);
            }
            else
            {
                builder.AddAttribute(
                    4,
                    nameof(FormElementBase<TValue>.ValueExpression),
                    ValueReference.ValueExpression);
            }

            builder.AddAttribute(
                5,
                nameof(FormElementBase<TValue>.FieldIdentifier),
                ValueReference.Key);

            builder.CloseComponent();
        }
    }
}
