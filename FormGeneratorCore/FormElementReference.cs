using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace FormGenerator.Core
{
    public class FormElementReference<TValue>
    {
        private TValue _value;

        public TValue Value
        {
            get => _value;
            set
            {
                _value = value;
                if (ValueChanged.HasDelegate)
                {
                    ValueChanged.InvokeAsync(_value);
                }
            }
        }

        public EventCallback<TValue> ValueChanged { get; set; }

        public string Key { get; internal set; }

        public Expression<Func<TValue>> ValueExpression { get; set; }

        public static void SetValue(
            object model,
            string key,
            TValue value)
        {
            var modelType = model.GetType();

            if (modelType == typeof(ExpandoObject))
            {
                var accessor = (IDictionary<string, object>)model;
                accessor[key] = value;
            }
            else
            {
                var propertyInfo = modelType.GetProperty(key);
                propertyInfo.SetValue(
                    model,
                    value);
            }
        }

        public static TValue GetValue(
            object model,
            string key)
        {
            var modelType = model.GetType();

            if (modelType == typeof(ExpandoObject))
            {
                var accessor = (IDictionary<string, object>)model;
                return (TValue)accessor[key];
            }
            else
            {
                var propertyInfo = modelType.GetProperty(key);
                return (TValue)propertyInfo.GetValue(model);
            }
        }
    }
}
