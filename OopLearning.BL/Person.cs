using System;
using System.Collections.Generic;
using System.Text;

namespace OopLearning.BL
{
    public class Person
    {
        private string name;
        private DateTime birthDate;
        private string cpr;
        private bool isWoman;

        public Person(string name, DateTime birthDate, string cpr, bool isWoman)
        {
            Name = name;
            BirthDate = birthDate;
            Cpr = cpr;
            IsWoman = isWoman;
        }
        public string Name
        {
            get { return name; }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateName(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(name), validationResult.errorMessage);
                }
                if(value != name)
                {
                    name = value;
                }
            }
        }
        public DateTime BirthDate { get; }
        public string Cpr { get; set; }
        public bool IsWoman { get; set; }

        public static (bool, string) ValidateName(string name)
        {
            if(name is null)
            {
                return (false, "Navnet er null!");
            }
            if(name.Length < 2)
            {
                return (false, "Navnet skal være større end 1!");
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                return (false, "Navnet indeholder kun whitespaces!");
            }
            if(!name.Contains(" "))
            {
                return (false, "Navnet skal indeholde mindst 1 mellemrum!");
            }
            else
            {
                return (true, "");
            }
        }
    }
}