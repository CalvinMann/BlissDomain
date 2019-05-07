using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Biometrics
{
    public class BodyDimensions : IEntity , IBodyDimensions
    {
        public BodyDimensions()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }

        public UnitsNet.Length Waist {  set; get; }

        public UnitsNet.Length Height {  set; get; }

        public UnitsNet.Length ShoeSize { set; get; }
    }
}
