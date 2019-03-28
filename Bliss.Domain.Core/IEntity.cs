using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Core
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
