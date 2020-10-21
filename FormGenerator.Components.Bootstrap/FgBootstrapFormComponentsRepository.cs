using System;
using System.Collections.Generic;
using FormGenerator.Core;
using FormGenerator.Core.Repository;
using FormGenerator.Form.Components.Bootstrap;
using FormGenerator.Form.Components.Plain;
using FormGenerator.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace FormGenerator.Repository.Bootstrap
{
    public class FgBootstrapFormComponentsRepository : FormGeneratorComponentModelBasedRepository
    {
        public FgBootstrapFormComponentsRepository()
        {
            _ComponentDict = new Dictionary<Type, Type>()
            {
                { typeof(string), typeof(BootstrapInputText) },
                { typeof(DateTime), typeof(InputDate<>) },
                { typeof(bool), typeof(BootstrapInputCheckbox) },
                { typeof(Enum),  typeof(BootstrapInputSelectWithOptions<>) },
                { typeof(ValueReferences), typeof(BootstrapInputCheckboxMultiple<>) },
                { typeof(decimal), typeof(BootstrapInputNumber<>) },
                { typeof(FgColor), typeof(InputColor) }
            };

            _DefaultComponent = null;
        }
    }
}
