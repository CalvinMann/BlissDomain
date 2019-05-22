using Bliss.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Biometrics
{
    //I think this could be converted to a value object
    public class BodyDimensions : IEntity , IBodyDimensions
    {
        public BodyDimensions()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }


        //I think each of these measurements need to be converted to value objects
        public UnitsNet.Length Waist {  set; get; }

        public UnitsNet.Length Height {  set; get; }

        public UnitsNet.Length ShoeSize { set; get; }
    }
}
