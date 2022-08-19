using System;
using System.Collections.Generic;
using CustomerProj.Entities;
using CustomerProj.Validators;
using FluentValidation.TestHelper;

namespace CustomerProj
{
    public class CustomerTests
    {

        public CustomerValidator customerValidator = new CustomerValidator();

        [Fact]
        public void ShouldCreateCustomer()
        {

            AddressCreateParams addressCreateParams = new AddressCreateParams();
            addressCreateParams.AddressLine1 = "Mulholland Drive";
            addressCreateParams.AddressLine2 = "13/1";
            addressCreateParams.AddressTypeParam = AddressType.Shipping;
            addressCreateParams.City = "Los Angeles";
            addressCreateParams.PostalCode = "90012";
            addressCreateParams.State = "Mulholland Drive";
            addressCreateParams.Country = "USA";
            Address addressNumber1 = new Address(addressCreateParams);

            List<Address> customerAddresses = new List<Address>();
            customerAddresses.Add(addressNumber1);

            List<string> testNotes = new List<string>();
            testNotes.Add("some note");

            Customer newCustomer = new Customer()
            {
                FirstName = "John",
                LastName = "Wayne",
                Addresses = customerAddresses,
                PhoneNumber = "+123456789",
                Email = "johnWayne@gmail.com",
                Notes = testNotes,
                TotalPurchasesAmount = 10
            };

            Assert.Equal("John", newCustomer.FirstName);
            Assert.Equal("Wayne", newCustomer.LastName);
            Assert.Equal(customerAddresses, newCustomer.Addresses);
            Assert.Equal("+123456789", newCustomer.PhoneNumber);
            Assert.Equal("johnWayne@gmail.com", newCustomer.Email);
            Assert.Equal(testNotes, newCustomer.Notes);
            Assert.Equal(10, newCustomer.TotalPurchasesAmount);
        }

        [Fact]
        public void SetParametersOneWhenShouldThrowExceptions()
        {
            string str = new string('A', 51);

            

        Customer customer = new Customer()
            {
                FirstName = str,
                LastName = str,
                Addresses = new List<Address>(),
                PhoneNumber = "+1508dfgdfg78682dfgfdgdf",
                Email = "myMail",
                Notes = new List<string>{},
                TotalPurchasesAmount = -1
            };
            
        var result = customerValidator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.Addresses);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
            result.ShouldHaveValidationErrorFor(x => x.Email);
            result.ShouldHaveValidationErrorFor(x => x.Notes);
            result.ShouldHaveValidationErrorFor(x => x.TotalPurchasesAmount);

        }
    }
}