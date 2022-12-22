using System;
using System.Linq;
using TextCopy;


namespace cHeaders
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
                return;
            }

            string result = CreateHeader(args);
            if (result == null)
            {
                Console.WriteLine("Слишком длинный ввод!");
                return;
            }

            Clipboard.SetText(result);
            Console.WriteLine(result);
            Console.WriteLine("Результат сокпирован в буффер обмена");
        }

        static void PrintHelp()
        {
            Console.WriteLine("Добро пожаловать в приложение cHeaders!");
            Console.WriteLine("Для работы вызовите с аргументами-названием заголовка.");
            Console.WriteLine("Программа автоматически добавит форматированную стоку в буффер обмена");
            Console.WriteLine("Например:");
            Console.WriteLine("> cHeaders functions prototypes");
            Console.WriteLine("Вывод:");
            Console.WriteLine("/* -------------------------- FUNCTIONS PROTOTYPES -------------------------- */");
            Console.WriteLine("Результат сокпирован в буффер обмена");
            Console.WriteLine("В буффер обмена скопируется:");
            Console.WriteLine("/* -------------------------- FUNCTIONS PROTOTYPES -------------------------- */");
            Console.WriteLine("До встречи!");
        }

        static string CreateHeader(string[] args)
        {
            string name = args.Aggregate((a, b) => a + " " + b).ToUpperInvariant();

            int numberOfMinuses = 80 - name.Length - 8;
            if (numberOfMinuses < 0)
                return null;
            int numberOfMinusesL = 0;
            int numberOfMinusesR = 0;

            if (numberOfMinuses % 2 == 1)
            {
                numberOfMinusesR = numberOfMinuses / 2;
                numberOfMinusesL = numberOfMinusesR + 1;
            }
            else
            {
                numberOfMinusesL = numberOfMinusesR = numberOfMinuses / 2;
            }

            return $"/* {new string('-', numberOfMinusesL)} {name} {new string('-', numberOfMinusesR)} */";
        }

    }
}
