using Bliss.Domain.Consultations;
using Bliss.Domain.Core;
using Bliss.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Domain.Consultations
{
    //I think this needs to be an entity vs a value object 
    public sealed class Availability : IEntity
    {

        public Availability(Date date, Zone zone, Time startTime, Duration duration)
        {
            this.Id = Guid.NewGuid();
            this.Date = date;
            this.Zone = zone;
            this.StartTime = startTime;
            this.Duration = duration;
        }

        public Guid Id { get; private set; }

        public Date Date { get; private set; }

        public Zone Zone { get; private set; }

        public Time StartTime { get; private set; }

        public Duration Duration { get; private set; }

    }
}
