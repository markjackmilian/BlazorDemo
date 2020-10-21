using System;
using System.Collections.Generic;
using FormGenerator.Form.Components.Plain;
using FormGenerator.Core.Repository;
using Microsoft.AspNetCore.Components.Forms;
using FormGenerator.Models;
using FormGenerator.Core;

namespace FormGenerator.Repository.Bootstrap
{
    public class FgComponentsRepository : FormGeneratorComponentModelBasedRepository
    {
        public FgComponentsRepository()
        {
            _ComponentDict = new Dictionary<Type, Type>
            {
                { typeof(string), typeof(FgInputText) },
                { typeof(DateTime), typeof(InputDate<>) },
                { typeof(bool), typeof(FgInputCheckbox) },
                { typeof(Enum), typeof(InputSelectWithOptions<>) },
                { typeof(ValueReferences), typeof(InputCheckboxMultiple<>) },
                { typeof(decimal), typeof(InputNumber<>) },
                { typeof(FgColor), typeof(InputColor) }
            };
            _DefaultComponent = null;
        }
    }
}
