using System;
using System.Collections.Generic;
using System.Linq;

public class PrettyPrinting
{
    class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        public override string ToString()
        {
            return Street + " " + City;
        }
    }

    class ImmutablePersonalName
    {
        public ImmutablePersonalName(string firstName, string lastName, Address address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address; // safe because immuable
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Address Address { get; private set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Address;
        }
    }


    public static void Main()
    {
        Console.WriteLine(new ImmutablePersonalName("John", "Connor", new Address("NA", "Los Angeles")));
        Console.ReadKey();
    }


}
