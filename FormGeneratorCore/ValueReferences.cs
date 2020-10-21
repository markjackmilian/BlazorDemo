using System;
using System.Collections.Generic;
using System.Linq;

namespace FormGenerator.Core
{
    public class ValueReferences<T> : ValueReferences
    {
        public ValueReferences()
        {
            var values = typeof(T).GetEnumValues()
                .Cast<T>()
                .Select(m => new ValueReference<string, bool>() { Key = m.ToString(), Value = false })
                .ToList();

            this.AddRange(values);
        }
    }

    public class ValueReferences : List<ValueReference<string, bool>>
    {

    }
}
