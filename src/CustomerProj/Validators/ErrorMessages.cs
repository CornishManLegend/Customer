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
        public const string LastNameIsRequiredException = "Last name is required!";
        public const string LastNameMaxLenghtException = "Exceeded the length of the last name in 50 characters";
        public const string AddressMissingException = "The addresse is missing";
        public const string AddressNotEnoughException = "Insufficient number of addresses specified";
        public const string IncorrectPhoneNumberFormat = "Incorrect the phone number format";
        public const string IncorrectEmailNumberFormat = "Incorrect the email format";
        public const string NotesMissingException = "Notes are missing";
        public const string NotesNotEnoughException = "The required number of notes are missing";
        public const string IncorrectTotalPurchasesAmountFormat = "The value of the total number of purchases is erroneous";
    }
}
