using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationHandout
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
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            GPA = gpa;
        }

        public override string ToString()
        {
             return $"{LastName}, {FirstName} Major: {Major} GPA: {GPA} ({CalculateDistinction()})";
        }
        public string CalculateDistinction()
        {
            string Distinction;
            if (GPA > 3.4 & GPA < 3.59)
            {
                Distinction = "cum laude";
            }
            if (GPA > 3.6 & GPA < 3.79)
            {
                Distinction = "magna cum laude";
            }
            if (GPA > 3.8 & GPA < 4.0)
            {
                Distinction = "summa cum laude";
            }
            else
            {
                Distinction = "No special distinction";
            }
            
            return Distinction;
        }

        public void SetAddress(int streetnumber, string streetName, string state, string city, int zipcode)
        {
            Address NewAddress = new Address();
            
            streetnumber = NewAddress.StreetNumber;
            streetName = NewAddress.StreetName;
            state = NewAddress.State;
            city = NewAddress.City;
            zipcode = NewAddress.ZipCode;

        }
    }
    public class Address
    {
        public int StreetNumber {get; set;}
        public string StreetName {get; set;}
        public string State {get; set;}
        public string City {get; set;}
        public int ZipCode { get; set; }

        public Address()
        {
            StreetNumber = 0;
            StreetName = string.Empty;
            State = string.Empty;
            City = string.Empty;
            ZipCode = 0;
        }
        
        public Address(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            StreetNumber = streetnumber;
            StreetName = streetname;
            State = state;
            City = city;
            ZipCode = zipcode;
        }

    }
}
