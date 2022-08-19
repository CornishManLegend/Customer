using CustomerProj.Entities;
using CustomerProj.Validators;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProj.Tests
{
    public class AddressTests
    {

        [Fact]
        public void ShouldCreateAddress()
        {

            AddressCreateParams addressCreateParams = new AddressCreateParams();
            addressCreateParams.AddressLine1 = "Mulholland Drive";
            addressCreateParams.AddressLine2 = "13/1";
            addressCreateParams.AddressTypeParam = AddressType.Shipping;
            addressCreateParams.City = "Los Angeles";
            addressCreateParams.PostalCode = "90012";
            addressCreateParams.State = "California";
            addressCreateParams.Country = "USA";
            Address addressNumber1 = new Address(addressCreateParams);

            Assert.NotNull(addressNumber1);
            Assert.Equal("Mulholland Drive", addressNumber1.AddressLine1);
            Assert.Equal("13/1", addressNumber1.AddressLine2);
            Assert.Equal("Los Angeles", addressNumber1.City);
            Assert.Equal("90012", addressNumber1.PostalCode);
            Assert.Equal("California", addressNumber1.State);
            Assert.Equal("USA", addressNumber1.Country);
        }


        [Fact]
        public void SetParametersOneWhenShouldThrowExceptions()
        {
            AddressValidator addressValidator = new AddressValidator();

            AddressCreateParams addressCreateParams = new AddressCreateParams();
            addressCreateParams.AddressLine1 = "";
            addressCreateParams.AddressLine2 = "";
            addressCreateParams.AddressTypeParam = AddressType.Unknown;
            addressCreateParams.City = "";
            addressCreateParams.PostalCode = "";
            addressCreateParams.State = "";
            addressCreateParams.Country = "";
            Address newAdress = new Address(addressCreateParams);

            var result = addressValidator.TestValidate(newAdress);

            result.ShouldHaveValidationErrorFor(x => x.AddressLine1);
            result.ShouldHaveValidationErrorFor(x => x.AddressTypeParam);
            result.ShouldHaveValidationErrorFor(x => x.City);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode);
            result.ShouldHaveValidationErrorFor(x => x.State);
            result.ShouldHaveValidationErrorFor(x => x.Country);
        }


        [Fact]
        public void SetParametersTwoWhenShouldThrowExceptions()
        {
            AddressValidator addressValidator = new AddressValidator();

            string addressLine1 = new string('A', 101);
            string addressLine2 = new string('A', 101);
            string city = new string('A', 51);
            string postalCode = new string('A', 7);
            string state = new string('A', 21);
            string country = "Russia";

            AddressCreateParams addressCreateParams = new AddressCreateParams();
            addressCreateParams.AddressLine1 = addressLine1;
            addressCreateParams.AddressLine2 = addressLine2;
            addressCreateParams.AddressTypeParam = AddressType.Shipping;
            addressCreateParams.City = city;
            addressCreateParams.PostalCode = postalCode;
            addressCreateParams.State = state;
            addressCreateParams.Country = country;
            Address newAdress = new Address(addressCreateParams);

            var result = addressValidator.TestValidate(newAdress);

            result.ShouldHaveValidationErrorFor(x => x.AddressLine1);
            result.ShouldHaveValidationErrorFor(x => x.AddressLine2);
            result.ShouldHaveValidationErrorFor(x => x.City);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode);
            result.ShouldHaveValidationErrorFor(x => x.State);
            result.ShouldHaveValidationErrorFor(x => x.Country);

        }

    }
}
