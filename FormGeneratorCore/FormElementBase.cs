using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FormGenerator.Core.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Core
{
    public class FormElementBase<TFormElement> : OwningComponentBase
    {
        private string _label;
        private string _inputType;

        [Inject]
        protected IFormGeneratorComponentsRepository Repo { get; set; }

        public string CssClass { get => string.Join(" ", CssClasses.ToArray()); }

        [Parameter]
        public List<string> CssClasses { get; set; }

        [Parameter]
        public List<string> DefaultFieldClasses { get; set; }

        [Parameter]
        public string Id { get; set; }

        [CascadingParameter]
        EditContext CascadedEditContext { get; set; }

        [Parameter]
        public string Label
        {
            get
            {
                var modelType = CascadedEditContext.Model.GetType();

                if (modelType == typeof(ExpandoObject))
                {
                    return FieldIdentifier;
                }
                else
                {
                    var dd = CascadedEditContext.Model
                        .GetType()
                        .GetProperty(FieldIdentifier)
                        .GetCustomAttributes(
                            typeof(DisplayAttribute),
                            false)
                        .FirstOrDefault() as DisplayAttribute;

                    return _label ?? dd?.Name;
                }
            }
            set
            {
                _label = value;
            }
        }

        protected override void OnInitialized()
        {

        }

        [Parameter]
        public string FieldIdentifier { get; set; }

        [Parameter]
        public EventCallback<TFormElement> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TFormElement>> ValueExpression { get; set; }

        [Parameter]
        public TFormElement Value { get; set; }

        [Parameter]
        public string InputType
        {
            get
            {
                var modelType = CascadedEditContext.Model.GetType();

                if (modelType == typeof(ExpandoObject))
                {
                    return FieldIdentifier;
                }
                else
                {
                    var dd = CascadedEditContext.Model
                        .GetType()
                        .GetProperty(FieldIdentifier)
                        .GetCustomAttributes(
                            typeof(DataTypeAttribute),
                            false)
                        .FirstOrDefault() as DataTypeAttribute;

                    string type = string.Empty;
                    switch (dd?.DataType)
                    {
                        case DataType.Password:
                            type = "password";
                            break;
                        default:
                            break;
                    }

                    return _inputType ?? type;
                }
            }
            set
            {
                _inputType = value;
            }
        }

        public RenderFragment CreateComponent() => builder =>
        {
            var componentType = Repo.GetComponent(typeof(TFormElement));

            //TODO: Add the dynamic version for getting a component

            if (componentType == null) return;

            var elementType = componentType;

            if (elementType.IsGenericTypeDefinition)
            {
                Type[] typeArgs = { Value.GetType() };
                elementType = elementType.MakeGenericType(typeArgs);
            }

            //var instance = Activator.CreateInstance(elementType);

            this.CreateFormComponent(
                this,
                CascadedEditContext.Model,
                FieldIdentifier,
                builder,
                elementType);
        };

        public void CreateFormComponent(
            object target,
            object dataContext,
            string fieldIdentifier,
            RenderTreeBuilder builder,
            Type elementType)
        {
            var treeIndex = 0;

            builder.OpenComponent(
                treeIndex,
                elementType);

            builder.AddAttribute(
                treeIndex++,
                nameof(InputBase<TFormElement>.Value),
                Value);

            builder.AddAttribute(
                treeIndex++,
                nameof(InputBase<TFormElement>.ValueChanged),
                ValueChanged);

            builder.AddAttribute(
                treeIndex++,
                nameof(InputBase<TFormElement>.ValueExpression),
                ValueExpression);

            builder.AddAttribute(
                treeIndex++,
                "class",
                GetDefaultFieldClasses(Activator.CreateInstance(elementType) as InputBase<TFormElement>));

            CheckForInterfaceActions(
                this,
                CascadedEditContext.Model,
                fieldIdentifier,
                builder,
                treeIndex++,
                elementType);

            builder.CloseComponent();
        }

        private void CheckForInterfaceActions(
            object target,
            object dataContext,
            string fieldIdentifier,
            RenderTreeBuilder builder,
            int indexBuilder,
            Type elementType)
        {
            if (FgHelpers.TypeImplementsInterface(
                elementType,
                typeof(IRenderChildren)))
            {
                var method = elementType.GetMethod(
                    nameof(IRenderChildren.RenderChildren),
                    BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static);

                method.Invoke(
                    null,
                    new object[]
                    {
                        builder,
                        indexBuilder,
                        dataContext,
                        fieldIdentifier
                    });
            }
        }

        private string GetDefaultFieldClasses<T>(InputBase<T> instance)
        {
            var output = DefaultFieldClasses == null ? "" : string.Join(" ", DefaultFieldClasses);

            if (instance == null) return output;

            var AdditionalAttributes = instance.AdditionalAttributes;

            if (AdditionalAttributes != null &&
                AdditionalAttributes.TryGetValue(
                    "class",
                    out var @class) &&
                    !string.IsNullOrEmpty(
                        Convert.ToString(@class)))
            {
                return $"{@class} {output}";
            }

            return output;
        }
    }
}
