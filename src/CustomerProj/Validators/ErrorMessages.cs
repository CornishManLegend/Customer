using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Validators
{
    public class ErrorMessages
    {
        public const string FirstNameMaxLenghtException = "Exceeded the length of the name in 50 characters";
        public const string LastNameIsRequiredException = "Last name is required";
        public const string LastNameMaxLenghtException = "Exceeded the length of the last name in 50 characters";
        public const string AddressMissingException = "The addresse is missing";
        public const string AddressNotEnoughException = "Insufficient number of addresses specified";
        public const string IncorrectPhoneNumberFormat = "Incorrect the phone number format";
        public const string IncorrectEmailNumberFormat = "Incorrect the email format";
        public const string NotesMissingException = "Notes are missing";
        public const string NotesNotEnoughException = "The required number of notes are missing";
        public const string IncorrectTotalPurchasesAmountFormat = "The value of the total number of purchases is erroneous";

        public const string AddressLine1IsRequiredException = "Address line 1 is required";
        public const string AddressLine1MaxLenghtException = "Exceeded the length of the AddressLine1 in 100 characters";
        public const string AddressLine2MaxLenghtException = "Exceeded the length of the AddressLine2 in 100 characters";

        public const string AddressTypeUnknownException = "AddressType is unknown";
        public const string AddressTypeException = "AddressType should be Shipping or Billing";

        public const string CityIsRequiredException = "City name is required";
        public const string CityMaxLenghtException = "Exceeded the length of the City name in 50 characters";

        public const string PostalCodeIsRequiredException = "PostalCode is required";
        public const string PostalCodeMaxLenghtException = "Exceeded the length of the PostalCode in 6 characters";

        public const string StateNameIsRequiredException = "State name is required";
        public const string StateNameMaxLenghtException = "Exceeded the length of the state name in 20 characters";

        public const string CountryNameIsRequiredException = "Country name is required";
        public const string InvalidCountryName = "Country name should be USA or Canada";
    }
}
