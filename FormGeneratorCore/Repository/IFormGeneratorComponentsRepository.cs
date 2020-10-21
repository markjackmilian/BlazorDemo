using System;

namespace FormGenerator.Core.Repository
{
    public interface IFormGeneratorComponentsRepository
    {
        public void RegisterComponent(
            object key,
            Type component);

        public void RemoveComponent(object key);

        public Type GetComponent(object key);
    }
}
