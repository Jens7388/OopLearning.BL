using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OopLearning.BL
{
    public class Person
    {
        private string name;
        private string cpr;

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
                    throw new ArgumentException(nameof(name), validationResult.errorMessage);
                }
                if(value != name)
                {
                    name = value;
                }
            }
        }

        public DateTime BirthDate { get; }

        public string Cpr
        {
            get { return cpr; }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateCpr(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(cpr), validationResult.errorMessage);
                }
                if(value != cpr)
                {
                    cpr = value;
                }
            }
        }

        public bool IsWoman { get;}

        public static (bool, string) ValidateName(string name)
        {
            if(name is null)
            {
                return (false, "Navnet er null!");
            }

            if(string.IsNullOrWhiteSpace(name))
            {
                return (false, "Navnet indeholder kun whitespaces!");
            }
            if(name.Length < 2)
            {
                return (false, "Navnet skal være større end 1!");
            }
            if(!name.Contains(" "))
            {
                return (false, "Navnet skal indeholde mindst 1 mellemrum!");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateCpr(string cpr)
        {
            if(cpr.Length != 10)
            {
                return (false, "CPR må kun være på 10 cifre!");
            }
            else
            {
                string date = cpr.Substring(0, 6);
                DateTime birthDate;
                if(!DateTime.TryParseExact(date, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    return (false, "Datoen i cpr-nummeret er ugyldigt!");
                }
                if(birthDate > DateTime.Now)
                {
                    return (false, "Datoen i cpr-nummeret ligger i fremtiden!");
                }
                else
                {
                    return (true, String.Empty);
                }
            }
        }
    }
}