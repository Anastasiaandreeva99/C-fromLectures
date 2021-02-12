using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBindingExample7
{
    public class MyAgeValidationRule : ValidationRule
    {
        private int minAge;

        public int MinAge
        {
            get { return minAge; }
            set { minAge = value >= 0 ? value : 0; }
        }
        private int maxAge;

        public int MaxAge
        {
            get { return maxAge; }
            set { maxAge = value >= 0 ? value : 0; }
        }

        public override ValidationResult Validate(object value,
                                                 CultureInfo cultureInfo)
        {
            bool result = double.TryParse((string)value, out var newAge);
            if (!result)
                return new ValidationResult(false, "Wrong input.");
            if (newAge >= minAge && newAge <= maxAge)
            {
                // the rule passed
                return new ValidationResult(true, null);
            }
            else
            {
                // the rule failed
                return new ValidationResult(false,
                    $"Age must be between {minAge} and {maxAge}");
            }
        }
    }
}

