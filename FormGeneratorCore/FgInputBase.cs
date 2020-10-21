using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FormGenerator.Core
{
    public abstract class FgInputBase<TValue> : InputBase<TValue>
    {
        private string id = Guid.NewGuid().ToString();

        [Parameter]
        public string Id { get => id; set => id = value; }
    }
}
