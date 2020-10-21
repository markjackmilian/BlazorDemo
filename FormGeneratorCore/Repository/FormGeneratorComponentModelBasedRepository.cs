using System;

namespace FormGenerator.Core.Repository
{
    public class FormGeneratorComponentModelBasedRepository : FormGeneratorComponentsRepository<Type>
    {
        protected override Type GetComponent(Type key)
        {
            var type = key;

            if (key.IsEnum)
            {
                type = typeof(Enum);
            }
            else if (key.BaseType == typeof(ValueReferences))
            {
                type = typeof(ValueReferences);
            }

            return base.GetComponent(type);
        }
    }
}
