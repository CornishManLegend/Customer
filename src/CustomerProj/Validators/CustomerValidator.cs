using CustomerProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace CustomerProj.Validators
{
    public class CustomerValidator
    {
        private const int FirstNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const int AddressesMinCount = 1;
        private const int NotesMinCount = 1;
        private static readonly Regex PhoneRegex = new Regex(@"^\+?[1-9]\d{1,14}$");
        private static readonly Regex EmailRegex = new Regex(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

        public static List<string> CustomerValidate(Customer customer)
        {

            List<string> errorsList = new List<string>();

            if (customer.FirstName.Length > FirstNameMaxLength)
            {
                errorsList.Add(ErrorMessages.FirstNameMaxLenghtException);
            }
            if (String.IsNullOrEmpty(customer.LastName))
            {
                errorsList.Add(ErrorMessages.LastNameIsRequiredException);
            }
            if (customer.LastName.Length > LastNameMaxLength)
            {
                errorsList.Add(ErrorMessages.LastNameMaxLenghtException);
            }
            if (customer.Addresses == null || customer.Addresses.Count < AddressesMinCount)
            {
                errorsList.Add(ErrorMessages.AddressNotEnoughException);
            }
            if ((customer.PhoneNumber != null) && !PhoneRegex.IsMatch(customer.PhoneNumber))
            {
                errorsList.Add(ErrorMessages.IncorrectPhoneNumberFormat);
            }
            if (customer.Email != null && !EmailRegex.IsMatch(customer.Email))
            {
                errorsList.Add(ErrorMessages.IncorrectEmailNumberFormat);
            }
            if (customer.Notes == null || customer.Notes.Count < NotesMinCount)
            {
                errorsList.Add(ErrorMessages.NotesNotEnoughException);
            }
            if (customer.TotalPurchasesAmount != null && customer.TotalPurchasesAmount < 0)
            {
                errorsList.Add(ErrorMessages.IncorrectTotalPurchasesAmountFormat);
            }

            return errorsList;
        }
    }
}
