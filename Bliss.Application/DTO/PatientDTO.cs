using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bliss.Application.DTO
{
    public class PatientDTO
    {
        public PatientDTO(string firstName, string lastName
            , string street1, string street2, 
            string city, string state, string zip,
            string cellPhoneNumber,string homePhoneNumber,
            char gender, string ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            Zip = zip;
            CellPhoneNumber = cellPhoneNumber;
            HomePhoneNumber = homePhoneNumber;
            Gender = gender;
            SSN = ssn;
        }

        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string SSN { get; private set; }
        public string Street1 { get; private set; }
        public string Street2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        public string CellPhoneNumber { get; private set; }
        public string HomePhoneNumber { get; private set; }
        public char Gender { get; private set; }

    }
}
