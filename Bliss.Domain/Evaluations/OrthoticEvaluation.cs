﻿using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations
{
    public class OrthoticEvaluation : IAggregateRoot, IEvaluation
    {

        public OrthoticEvaluation(EvaluationType evaluationType)
        {
            //init 
            Id = Guid.NewGuid();
            EvaluationType = evaluationType;
            CreationDate = new Date(DateTime.Now);
        }

        public Guid Id { private set; get; }

        public EvaluationType EvaluationType { private set; get; }

        public Date CreationDate { private set; get; }

        public Date LastUpdatedDate { private set; get; }
    }
}
