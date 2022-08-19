using CustomerProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Validators
{
    public class AddressValidator
    {
        public static List<string> ValidateAddress(Address address)
        {
            List<string> errors = new List<string>();

            if (String.IsNullOrEmpty(address.AddressLine1))
            {
                errors.Add(ErrorMessages.AddressLine1IsRequiredException);
            }
            if (address.AddressLine1.Length > 100)
            {
                errors.Add(ErrorMessages.AddressLine1MaxLenghtException);
            }
            if (address.AddressLine2 != null && address.AddressLine2.Length > 100)
            {
                errors.Add(ErrorMessages.AddressLine2MaxLenghtException);
            }


            if(address.AddressType == AddressType.Unknown)
            {
                errors.Add(ErrorMessages.AddressTypeUnknownException);
            }
            if (!(address.AddressType == AddressType.Shipping || address.AddressType == AddressType.Billing))
            {
                errors.Add(ErrorMessages.AddressTypeException);
            }

            if (String.IsNullOrEmpty(address.City))
            {
                errors.Add(ErrorMessages.CityIsRequiredException);
            }
            if (address.City.Length > 50)
            {
                errors.Add(ErrorMessages.CityMaxLenghtException);
            }
            if (String.IsNullOrEmpty(address.PostalCode))
            {
                errors.Add(ErrorMessages.PostalCodeIsRequiredException);
            }
            if (address.PostalCode.Length > 6)
            {
                errors.Add(ErrorMessages.PostalCodeMaxLenghtException);
            }
            if (String.IsNullOrEmpty(address.State))
            {
                errors.Add(ErrorMessages.StateNameIsRequiredException);
            }
            if (address.State.Length > 20)
            {
                errors.Add(ErrorMessages.StateNameMaxLenghtException);
            }
            if (String.IsNullOrEmpty(address.Country))
            {
                errors.Add(ErrorMessages.CountryNameIsRequiredException);
            }
            if (address.Country != "USA")
            {
                errors.Add(ErrorMessages.InvalidCountryName);
            }
            if (address.Country != "Canada")
            {
                errors.Add(ErrorMessages.InvalidCountryName);
            }

            return errors;
        }


    }
}
