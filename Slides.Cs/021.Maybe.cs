using System;
using System.IO;
using System.Net;
class Maybe
{
    class PhoneNumber
    {
        public string Home { get; set; }
        public string Work { get; set; }
    }
    class Detail
    {
        public PhoneNumber PhoneNumber { get; set; }

        // More details
    }
    class Person
    {
        public Detail PersonalDetail { get; set; }
    }

    public static void Main()
    {
        var person = new Person();
        string homeNumber;
        if (person.PersonalDetail != null)
        {
            if (person.PersonalDetail.PhoneNumber != null)
            {
                if (person.PersonalDetail.PhoneNumber.Home != null)
                {
                    homeNumber = person.PersonalDetail.PhoneNumber.Home.ToUpper();
                }
                else homeNumber = "No home number";
            }
        }

    }
}