using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.ValueObjects
{
  
    public sealed class State
    {
        private static String states = "|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY|";

        private string _state;

        public State(string state)
        {
            //ensure zip is 5 charachers
            if (string.IsNullOrEmpty(state))
                throw new Exception("State cannot be empty");

            if (state.ToCharArray().Length != 2)
                throw new Exception("State must be 2 characters long");

            if((states.IndexOf(state) > 0) == false)
                throw new Exception("State abv is not valid");

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

    }
}




   

