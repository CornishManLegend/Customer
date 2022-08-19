using CustomerProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using FluentValidation;

namespace CustomerProj.Validators
{

    public class CustomerValidator : AbstractValidator<Customer>
    {
        private const int TotalPurchasesMinAmountValue = 0;
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName)
               .MaximumLength(50).WithMessage(ErrorMessages.FirstNameMaxLenghtException);
            RuleFor(c => c.LastName)
               .NotEmpty().WithMessage(ErrorMessages.LastNameIsRequiredException)
               .MaximumLength(50).WithMessage(ErrorMessages.LastNameMaxLenghtException);
            RuleFor(c => c.Addresses)
               .NotEmpty().WithMessage(ErrorMessages.AddressNotEnoughException);
            RuleFor(c => c.PhoneNumber)
               .Matches(@"^\+?[1 - 9]\d{ 1, 14}$").WithMessage(ErrorMessages.IncorrectPhoneNumberFormat);
            RuleFor(c => c.Email)
               .Matches(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$").WithMessage(ErrorMessages.IncorrectEmailNumberFormat);
            RuleFor(c => c.Notes)
               .NotEmpty().WithMessage(ErrorMessages.NotesNotEnoughException);
            RuleFor(c => c.TotalPurchasesAmount)
                .GreaterThan(TotalPurchasesMinAmountValue).WithMessage(ErrorMessages.IncorrectTotalPurchasesAmountValue);
        }
    }
}
