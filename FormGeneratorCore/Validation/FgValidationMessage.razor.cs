using System;

namespace FormGenerator.Core.Validation
{
    public class FgValidationMessageComponent<TValue> : ValidationMessageBase<TValue>
    {
        public override string ValidClass { get; set; } = "valid-feedback";
        public override string InValidClass { get; set; } = "invalid-feedback";
    }
}
