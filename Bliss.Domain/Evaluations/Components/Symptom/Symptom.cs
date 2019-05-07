using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Symptom
{
    public class Symptom : IEntity
    {

        public Symptom()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }

        public string Description {  set; get; }
    }
}
