using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Налаштування коректного відображення кирилиці в консолі
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("   ЗАВДАННЯ 1: ПЕРЕВІРКА КОРЕКТНОСТІ ЛОГІНА");
            Console.WriteLine("==================================================");

            // Регулярний вираз: перша літера, далі від 1 до 9 літер або цифр (загальна довжина 2-10)
            string loginPattern = @"^[a-zA-Z][a-zA-Z0-9]{1,9}$";
            Regex loginRegex = new Regex(loginPattern);

            string[] testLogins = 
            { 
                "User1",
                "ok",
                "1Admin",
                "Nick_Name",
                "A",
                "VeryLongLoginName"
            };

            foreach (var login in testLogins)
            {
                bool isValid = loginRegex.IsMatch(login);
                Console.WriteLine($"Логін: \"{login,-18}\" -> Статус: {(isValid ? "КОРЕКТНИЙ" : "НЕКОРЕКТНИЙ")}");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("   ЗАВДАННЯ 2: ФІЛЬТР ЦЕНЗУРИ СЛІВ");
            Console.WriteLine("==================================================");

            string filterPattern = @"\bспам[а-яіїєa-z]*\b";
            Regex filterRegex = new Regex(filterPattern, RegexOptions.IgnoreCase);

            string sampleText = "У чаті з'явився новий Спам, спамери почали спамити повідомленнями, а ми боремося зі СПАМОМ!";
            string replacement = "[заблоковано]";

            string processedText = filterRegex.Replace(sampleText, replacement);

            Console.WriteLine("Вихідний текст:");
            Console.WriteLine(sampleText);
            Console.WriteLine("\nТекст після фільтрації:");
            Console.WriteLine(processedText);
            Console.WriteLine("==================================================");
        }
    }
}