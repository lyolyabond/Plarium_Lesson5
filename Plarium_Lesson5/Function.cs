using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
     class Function
    {
        //Метод для вывода ошибки
        public static void IncorrectInput()
        {
            Console.Write("Некорректный ввод! Введите заново: ");
        }
        //Метод для ввода данных
        public static void Input(out int year, out int month, out int day)
        {
            Console.Write("Введите год: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year < 2000 || year >= 2100)
            {
                IncorrectInput();
            }

            Console.Write("Введите месяц: ");
            while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                IncorrectInput();
            }

            Console.Write("Введите день: ");
            while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
            {
                IncorrectInput();
            }
        }
    }
}
