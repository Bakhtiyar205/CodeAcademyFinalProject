using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Utilities.Validators
{
    public class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _maxValue;

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return Decimal.ToInt32((decimal)value) <= _maxValue;
        }
    }
}
