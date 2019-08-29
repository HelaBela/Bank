using System;

namespace Bank
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime DateOfBirth { get; }

        public string Email { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;

                var age = today.Year - DateOfBirth.Year;

                if (DateOfBirth.AddYears(age) > today) age--;

                return age;
            }
        }

        public Person(string name, string address, DateTime dateOfBirth, string email)
        {
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}