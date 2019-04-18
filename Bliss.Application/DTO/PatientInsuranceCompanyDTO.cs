using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Application.DTO
{
    public class PatientInsuranceCompanyDTO
    {
       public PatientInsuranceCompanyDTO(string companyName
           , string street1, string street2
           ,string city, string state, int zip
           , string customerServicePhoneNumber )
        {
            CompanyName = companyName;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Zip = zip;
            CustomerServicePhoneNumber = customerServicePhoneNumber;
        }

        public string CompanyName { get; private set; }
        public string Street1 { get; private set; }
        public string Street2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int Zip { get; private set; }
        public string CustomerServicePhoneNumber { get; private set; }
    }
}
