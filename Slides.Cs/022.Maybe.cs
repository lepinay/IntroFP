using System;
using System.IO;
using System.Net;
class Maybe3
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

    public static U Check<T,U>(T t, Func<T, U> cexpr)
    {
        if (t != null)
        {
            return cexpr(t);
        }
        else return default(U);
    }

    public static void Main()
    {
        var person = new Person();
        //string homeNumber;
        //if (person.PersonalDetail != null)
        //{
        //    if (person.PersonalDetail.PhoneNumber != null)
        //    {
        //        if (person.PersonalDetail.PhoneNumber.Home != null)
        //        {
        //            homeNumber = person.PersonalDetail.PhoneNumber.Home;
        //        }
        //        else homeNumber = "No home number";
        //    }
        //}

        var upperHomePhone = 
            Check(person.PersonalDetail, detail =>
            Check(detail.PhoneNumber, pn =>
            Check(pn.Home, home => home.ToUpper())));

        Console.WriteLine(upperHomePhone);



    }
}