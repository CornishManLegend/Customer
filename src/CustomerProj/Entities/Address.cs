using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Entities
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Unknown;
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string addressLine, string addressLine2, AddressType addressType, string city, string postalCode, string state, string country)
        {
            AddressLine1 = addressLine;
            AddressLine2 = addressLine2;
            AddressType = addressType;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
    }
}
