using System;
using System.Collections.Generic;
using CustomerProj.Entities;
using CustomerProj.Validators;

namespace CustomerProj
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldCreateCustomer()
        {
            List<Address> customerAddresses = new List<Address>();
            Address addressNumber1 = new Address("Mulholland Drive", "13/1", AddressType.Shipping, "Los Angeles", "90012", "California", "USA");
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
                Notes = new List<string> {},
                TotalPurchasesAmount = -1
            };
            var result = CustomerValidator.CustomerValidate(customer);

            Assert.Equal(ErrorMessages.FirstNameMaxLenghtException, result[0]);
            Assert.Equal(ErrorMessages.LastNameMaxLenghtException, result[1]);
            Assert.Equal(ErrorMessages.AddressNotEnoughException, result[2]);
            Assert.Equal(ErrorMessages.IncorrectPhoneNumberFormat, result[3]);
            Assert.Equal(ErrorMessages.IncorrectEmailNumberFormat, result[4]);
            Assert.Equal(ErrorMessages.NotesNotEnoughException, result[5]);
            Assert.Equal(ErrorMessages.IncorrectTotalPurchasesAmountFormat, result[6]);

        }

        [Fact]
        public void SetParametersTwoWhenShouldThrowExceptions()
        {

            Customer customer1 = new Customer()
            {
                FirstName = "John",
                LastName = "",
                Addresses = new List<Address>(),
                PhoneNumber = "+123456789",
                Email = "myMail@gmail.com",
                Notes = new List<string> { "new note" },
                TotalPurchasesAmount = 1
            };
            var result = CustomerValidator.CustomerValidate(customer1);

            Assert.Equal(ErrorMessages.LastNameIsRequiredException, result[0]);
            Assert.Equal(ErrorMessages.AddressNotEnoughException, result[1]);

        }

    }
}