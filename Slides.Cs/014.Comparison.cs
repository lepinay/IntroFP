using System;
using System.Collections.Generic;
using System.Linq;

public class Comparison
{
    class Address : IEquatable<Address>,IComparable<Address>
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

        public bool Equals(Address other)
        {
            return other.City == City && other.Street == Street;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Address addrObj = obj as Address;
            if (addrObj == null)
                return false;
            else
                return Equals(addrObj); 
        }

        public override int GetHashCode()
        {
            return Street.GetHashCode() ^ City.GetHashCode();
        }

        public static bool operator ==(Address adr1, Address adr2)
        {
            if ((object)adr1 == null || ((object)adr2) == null)
                return Object.Equals(adr1, adr2);

            return adr1.Equals(adr2);
        }

        public static bool operator !=(Address adr1, Address adr2)
        {
            if (adr1 == null || adr2 == null)
                return !Object.Equals(adr1, adr2);

            return !(adr1.Equals(adr2));
        }

        public int CompareTo(Address other)
        {
            var res = Street.CompareTo(other.Street);
            if (res != 0) return res;
            return City.CompareTo(other.City);
        }
    }

    class ImmutablePersonalName:IEquatable<ImmutablePersonalName>,IComparable<ImmutablePersonalName>
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

        public bool Equals(ImmutablePersonalName other)
        {
            return FirstName == other.FirstName
                && LastName == other.LastName
                && other.Address.Equals(Address);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            ImmutablePersonalName persObj = obj as ImmutablePersonalName;
            if (persObj == null)
                return false;
            else
                return Equals(persObj);
        }

        public override int GetHashCode()
        {
            return LastName .GetHashCode() ^ 
                FirstName.GetHashCode() ^ Address.GetHashCode() ;
        }

        public static bool operator ==(ImmutablePersonalName pers1, ImmutablePersonalName pers2)
        {
            if ((object)pers1 == null || ((object)pers2) == null)
                return Object.Equals(pers1, pers2);

            return pers1.Equals(pers2);
        }

        public static bool operator !=(ImmutablePersonalName adr1, ImmutablePersonalName adr2)
        {
            if (adr1 == null || adr2 == null)
                return !Object.Equals(adr1, adr2);

            return !(adr1.Equals(adr2));
        }

        public int CompareTo(ImmutablePersonalName other)
        {
            var res = LastName.CompareTo(other.LastName);
            if (res != 0) return res;
            res = FirstName.CompareTo(other.FirstName); 
            if (res != 0) return res;
            return Address.CompareTo(other.Address);
        }
    }


    public static void Main()
    {
        Console.WriteLine(new ImmutablePersonalName("John", "Connor", new Address("NA", "Los Angeles")));
        Console.ReadKey();
    }

}
