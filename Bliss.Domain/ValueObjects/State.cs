using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
  
    public sealed class State : ISubmitConsultationValidation
    {
        private static String states = "|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY|";

        private string _state;

        public State(string state)
        {

            _state = state;
        }

        public static implicit operator State(string state)
        {
            return new State(state);
        }

        public static implicit operator string(State state)
        {
            return state._state;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _state;
            }

            return ((State)obj)._state == _state;
        }

        public List<ValidationError> Validate()
        {
            List<ValidationError> validationErrors = new List<ValidationError>();

            //ensure zip is 5 charachers
            if (string.IsNullOrEmpty(_state))
            {
                validationErrors.Add(new ValidationError("State cannot be empty", nameof(SSN)));
                return validationErrors;
            }

            if (_state.ToCharArray().Length != 2)
                validationErrors.Add(new ValidationError("State must be 2 characters long", nameof(SSN)));

            if ((states.IndexOf(_state) > 0) == false)
                validationErrors.Add(new ValidationError("State abv is not valid", nameof(SSN)));

            if (string.IsNullOrWhiteSpace(_state))
                validationErrors.Add(new ValidationError("The 'SSN' field is required", nameof(SSN)));



            return validationErrors;
        }

    }
}




   

