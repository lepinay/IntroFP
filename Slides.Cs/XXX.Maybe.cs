using System;
using System.IO;
using System.Net;
class Maybe2
{
    class PhoneNumber
    {
        public Maybe<string> Home { get; set; }
        public Maybe<string> Work { get; set; }
    }
    class Detail
    {
        public Maybe<PhoneNumber> PhoneNumber { get; set; }

        // More details
    }
    class Person
    {
        public Maybe<Detail> PersonalDetail { get; set; }
    }

    #region secret magic

    class Maybe
    {
        public T Get<T>(T defaultValue)
        {
            if (this is Some<T>) return (this as Some<T>).Value;
            else return defaultValue;
        }
    }

    class Maybe<T> : Maybe
    {

    }

    class Some<T> : Maybe<T>
    {
        public T Value { get; set; }

        public Some(T t)
        {
            this.Value = t;
        }
    }

    class None : Maybe
    {

    }

    static Maybe Check<T>(Maybe<T> t, Func<T, Maybe> cexpr)
    {
        if (t is Some<T>)
        {
            return cexpr((t as Some<T>).Value);
        }
        else return new None();
    }
    #endregion

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
            Check(person.PersonalDetail, d =>
            Check(d.PhoneNumber, pn =>
            Check(pn.Home, home => new Some<string>(home.ToUpper()))))
            .Get("No home number");

        Console.WriteLine(upperHomePhone);



    }
}