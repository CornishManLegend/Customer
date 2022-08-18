using System.Collections.Generic;
using CustomerProj.Entities;

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
    }
}