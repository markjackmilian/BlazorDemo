using System;

namespace FormGenerator.Core
{
    public class ValueReference<TKey, TValue>
    {
        public TValue Value { get; set; }

        public TKey Key { get; set; }
    }
}
