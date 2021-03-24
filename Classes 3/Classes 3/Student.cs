using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_3
{
    public class Student
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Major {get; set;}
        public double GPA {get; set;}
        public Address Address { get; set; }

        public Student()
        {

            FirstName = string.Empty;
            LastName = string.Empty;
            Major = string.Empty;
            GPA = 0;
            Address = new Address();
        }
        public Student(string firstName, string lastName, string major, double gpa)
        {
            firstName = FirstName;
            lastName = LastName;
            major = Major;
            gpa = GPA;
        }
        public string CalculateDistinction()
        {
            string Distinction;
            if (GPA > 3.25 && GPA < 3.5)
            {
                Distinction = "good but not the best";
            }
            else if (GPA >= 3.5 && GPA < 3.8)
            {
                Distinction = "better";
            }
            else if (GPA > 3.8)
            {
                Distinction = "GOAT";
            }
            else
            {
                Distinction = "dookie";
            }

            return Distinction;
        }
        public void SetAddress(int steetnumber, string streetName, string state, string city, int zipcode)
        {
            Address = new Address(steetnumber, streetName, state, city, zipcode);
        }
        public override string ToString()
        {
            return $"{LastName}, {FirstName} majoring in {Major} ({CalculateDistinction()})";
        }

    }

    public class Address
    {
        public int StreetNumber {get;set;}
        public string StreetName {get;set;}
        public string State {get;set;}
        public string City {get;set;}
        public int Zipcode { get; set; }


        public Address()
        {
            StreetNumber = 0;
            StreetName = string.Empty;
            State = string.Empty;
            City = string.Empty;
            Zipcode = 0;
        }

        public Address(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            streetnumber = StreetNumber;
            streetname = StreetName;
            state = State;
            city = City;
            zipcode = Zipcode;
        }
    }
}
