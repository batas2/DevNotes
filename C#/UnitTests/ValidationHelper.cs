using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTests
{
    public static class ValidationHelper
    {
        public static void ValidateContract(object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var result = new List<ValidationResult>();
            var context = new ValidationContext(instance);

            if (!Validator.TryValidateObject(instance, context, result, true))
            {
                throw new InvalidOperationException(string.Join(Environment.NewLine, result.Select(r => r.ErrorMessage)));
            }
        }
        
        public static void ValidateContract(object instance, string messageOnError)
        {
            try
            {
                ValidateContract(instance);
            }
            catch(Exception e) when(e is InvalidOperationException || e is ArgumentNullException)
            {
                throw new InvalidOperationException(messageOnError + Environment.NewLine + e.Message, e);
            }
        }
    }
}
