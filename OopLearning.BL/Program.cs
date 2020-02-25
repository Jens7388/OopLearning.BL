using System;
using System.Globalization;

namespace OopLearning.BL
{
    class Program
    {
        static void Main()
        {
            MakePerson("Ib ", "1203567890");
        }
        private static void MakePerson(string nameInput, string cprInput)
        {            
            (bool isValid, string errorMessage) nameValidationResult = Person.ValidateName(nameInput);
            (bool isValid, string errorMessage) cprValidationResult = Person.ValidateCpr(cprInput);
            if(!nameValidationResult.isValid)
            {
                Console.WriteLine(nameValidationResult.errorMessage);
            }
            if(!cprValidationResult.isValid)
            {
                Console.WriteLine(cprValidationResult.errorMessage);
            }
            else if(nameValidationResult.isValid && cprValidationResult.isValid)
            {
                DateTime.TryParseExact(cprInput.Substring(0, 6), "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate);
                int.TryParse(cprInput.Substring(0, 10), out int cprGender);
                if(cprGender % 2 == 0)
                {
                    Person person = new Person(nameInput, birthDate, cprInput, true);
                    Console.WriteLine($"{nameInput}, {birthDate.ToString("dd-MM-yyyy")}, {cprInput}, Female");
                }
                else
                {
                    Person person = new Person(nameInput, birthDate, cprInput, false);
                    Console.WriteLine($"{nameInput}, {birthDate.ToString("dd-MM-yyyy")}, {cprInput}, Male");
                }
            }
        }
    }
}