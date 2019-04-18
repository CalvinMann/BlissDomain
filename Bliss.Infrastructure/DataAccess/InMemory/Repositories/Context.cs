using Bliss.Domain.Patients;
using Bliss.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Bliss.Infrastructure.DataAccess.InMemory.Repositories
{
    public sealed class Context
    {
        public Collection<Patient> Patients { get; set; }
        public Collection<Supplier> Suppliers { get; set; }

        public Context()
        {
            Patients = new Collection<Patient>();
            Suppliers = new Collection<Supplier>();
        }
    }
}
