using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public class Pain : IEntity, IPain
    {
        private Symptom _symptom;

        public Pain()
        {
            Id = Guid.NewGuid();

            _symptom = new Symptom();
           
        }

        public Guid Id { private set; get; }

        public PainLevel PainLevel => throw new NotImplementedException();

        public Frequency Frequency => throw new NotImplementedException();
    }
}
