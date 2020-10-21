using System;
using System.Reflection;
using Microsoft.AspNetCore.Components.Rendering;

namespace FormGenerator.Core
{
    public interface IRenderChildren
    {
        public static void RenderChildren(
            RenderTreeBuilder builder,
            int index,
            object dataContext,
            string fieldIdentifier) => throw new NotImplementedException();
    }

    public interface IRenderChildrenSwapable : IRenderChildren
    {
        public static void RenderChildren(
            RenderTreeBuilder builder,
            int index,
            object dataContext,
            string fieldIdentifier,
            Type typeOfChildToRender) => throw new NotImplementedException();
    }
}
