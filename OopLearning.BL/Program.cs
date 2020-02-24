using System;

namespace OopLearning.BL
{
    class Program
    {
        static void Main()
        {
            string nameInput = "Ib";
            string cprInput = "";
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
            else
            {
                Person person = new Person(nameInput, new DateTime(0001, 01, 01), cprInput, false);
            }
        }
    }
}