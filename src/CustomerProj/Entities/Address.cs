using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Entities
{
    public class Address
    {
        public string AddressLine1;
        public string AddressLine2;
        public string City;
        public AddressType AddressTypeParam;
        public string PostalCode;
        public string State;
        public string Country;

        public Address(AddressCreateParams addressCreateParams)
        {
            AddressLine1 = addressCreateParams.AddressLine1;
            AddressLine2 = addressCreateParams.AddressLine2;
            AddressTypeParam = addressCreateParams.AddressTypeParam;
            City = addressCreateParams.City;
            PostalCode = addressCreateParams.PostalCode;
            State = addressCreateParams.State;
            Country = addressCreateParams.Country;
        }

    }

    public class AddressCreateParams
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public AddressType AddressTypeParam { get; set; } = AddressType.Unknown;
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
