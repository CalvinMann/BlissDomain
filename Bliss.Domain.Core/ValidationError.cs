using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Core
{
    public class ValidationError
    {

        public ValidationError(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

         public  string ErrorMessage { get; private set; }

        public string PropertyName { get; private set; }
    }
}
