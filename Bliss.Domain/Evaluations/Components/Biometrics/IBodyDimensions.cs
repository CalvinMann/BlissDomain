using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Evaluations.Components.Biometrics
{
    public interface IBodyDimensions
    {
         UnitsNet.Length Waist { set; get; }

         UnitsNet.Length Height { set; get; }

        UnitsNet.Length ShoeSize { set; get; }
    }
}
