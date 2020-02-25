using System;
using System.Globalization;

namespace OopLearning.BL
{
    class Program
    {
        static void Main()
        {
            MakePerson("Ib ", "1203567890");
            MakeAccount("1234567890", "0420", 69000);
        }
        private static void MakePerson(string nameInput, string cprInput)
        {
            try
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }
        private static void MakeAccount(string accountNumberInput, string departmentNumberInput, decimal balanceInput)
        {
            try
            {
                Account account = new Account(accountNumberInput, departmentNumberInput, balanceInput);
                Console.WriteLine($"{accountNumberInput}, {departmentNumberInput}, {balanceInput}");
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}