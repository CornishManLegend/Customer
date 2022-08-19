using CustomerProj.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(c => c.AddressLine1)
                .NotEmpty().WithMessage(ErrorMessages.AddressLine1IsRequiredException)
                .MaximumLength(100).WithMessage(ErrorMessages.AddressLine1MaxLenghtException);

            RuleFor(c => c.AddressLine2)
                .MaximumLength(100).WithMessage(ErrorMessages.AddressLine2MaxLenghtException);

            RuleFor(c => c.AddressTypeParam)
                .NotEqual(AddressType.Unknown).WithMessage(ErrorMessages.AddressTypeUnknownException)
                .Equal(AddressType.Shipping).WithMessage(ErrorMessages.AddressTypeException)
                .Equal(AddressType.Billing).WithMessage(ErrorMessages.AddressTypeException);

            RuleFor(c => c.City)
                .NotEmpty().WithMessage(ErrorMessages.CityIsRequiredException)
                .MaximumLength(50).WithMessage(ErrorMessages.CityMaxLenghtException);

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage(ErrorMessages.PostalCodeIsRequiredException)
                .MaximumLength(6).WithMessage(ErrorMessages.PostalCodeMaxLenghtException);

            RuleFor(c => c.State)
                .NotEmpty().WithMessage(ErrorMessages.StateNameIsRequiredException)
                .MaximumLength(20).WithMessage(ErrorMessages.StateNameMaxLenghtException);

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage(ErrorMessages.CountryNameIsRequiredException)
                .Equal("USA").WithMessage(ErrorMessages.InvalidCountryName)
                .Equal("Canada").WithMessage(ErrorMessages.InvalidCountryName);

        }

    }
}
