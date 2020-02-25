using System;
using System.Globalization;

namespace OopLearning.BL
{
    class Program
    {
        static void Main()
        {
            MakePerson("Ib ", "1203567891");
            MakeAccount("1234567890", "0420", 69000);
            MakeField(6, 5, "Potatoes");
            Console.ReadLine();
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
                    Console.WriteLine($"Name: {nameInput}, birth date: {birthDate.ToString("dd-MM-yyyy")}, CPR: {cprInput}, gender: Female");
                }
                else
                {
                    Person person = new Person(nameInput, birthDate, cprInput, false);
                    Console.WriteLine($"Name: {nameInput}, birth date: {birthDate.ToString("dd-MM-yyyy")}, CPR: {cprInput}, gender: Male");
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
                Console.WriteLine($"Account number: {accountNumberInput}, department number: {departmentNumberInput}, balance: {balanceInput}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);              
            }
        }
        private static void MakeField(double widthInput, double lengthInput, string cropInput)
        {
            try
            {
                double area = (widthInput * lengthInput) / 10000;
                double yield = 0;
                if(cropInput.ToLower() == "potatoes")
                {
                    yield = 20 * area;
                }
                else if(cropInput.ToLower() == "wheat")
                {
                    yield = 10 * area;
                }
                else if(cropInput.ToLower() == "oak")
                {
                    yield = 15 * area;
                }
                else if(cropInput.ToLower() == "carrots")
                {
                    yield = 66.66 * area;
                }
                Field field = new Field(widthInput, lengthInput, area, cropInput, yield);
                Console.WriteLine($"Width: {widthInput} cm, length: {lengthInput} cm, area: {area} m2, crop: {cropInput}, yield: {yield} kg");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }
    }
}