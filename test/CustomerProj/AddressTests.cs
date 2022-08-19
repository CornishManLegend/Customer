using CustomerProj.Entities;
using CustomerProj.Validators;
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
            Address addressNumber1 = new Address("Mulholland Drive", "13/1", AddressType.Shipping, "Los Angeles", "90012", "California", "USA");

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
            Address newAdress = new Address("", "", AddressType.Unknown, "", "", "", "");

            var result = AddressValidator.ValidateAddress(newAdress);

            Assert.Equal(ErrorMessages.AddressLine1IsRequiredException, result[0]);
            Assert.Equal(ErrorMessages.AddressTypeUnknownException, result[1]);
            Assert.Equal(ErrorMessages.AddressTypeException, result[2]);
            Assert.Equal(ErrorMessages.CityIsRequiredException, result[3]);
            Assert.Equal(ErrorMessages.PostalCodeIsRequiredException, result[4]);
            Assert.Equal(ErrorMessages.StateNameIsRequiredException, result[5]);
            Assert.Equal(ErrorMessages.CountryNameIsRequiredException, result[6]);

        }


        [Fact]
        public void SetParametersTwoWhenShouldThrowExceptions()
        {

            string addressLine1 = new string('A', 101);
            string addressLine2 = new string('A', 101);
            string city = new string('A', 51);
            string postalCode = new string('A', 7);
            string state = new string('A', 21);
            string country = "Russia";

            Address newAdress = new Address
            (
                addressLine1,
                addressLine2,
                AddressType.Shipping,
                city,
                postalCode,
                state,
                country
            );

            var result = AddressValidator.ValidateAddress(newAdress);

            Assert.Equal(ErrorMessages.AddressLine1MaxLenghtException, result[0]);
            Assert.Equal(ErrorMessages.AddressLine2MaxLenghtException, result[1]);
            Assert.Equal(ErrorMessages.CityMaxLenghtException, result[2]);
            Assert.Equal(ErrorMessages.PostalCodeMaxLenghtException, result[3]);
            Assert.Equal(ErrorMessages.StateNameMaxLenghtException, result[4]);
            Assert.Equal(ErrorMessages.InvalidCountryName, result[5]);

        }

    }
}
