using System;
using System.Globalization;

namespace OopLearning.BL
{
    class Program
    {
        static void Main()
        {
            string nameInput = "Ib ";
            string cprInput = "1203567891";
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
                int.TryParse(cprInput.Substring(7, 10), out int cprGender);
                if(cprGender % 2 == 0)
                {
                    Person person = new Person(nameInput, birthDate, cprInput, true);
                }
                else
                {
                    Person person = new Person(nameInput, birthDate, cprInput, false);
                }
                
            }
        }
    }
}