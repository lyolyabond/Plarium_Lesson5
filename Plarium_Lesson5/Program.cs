using System;

namespace TaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            int year;
            int month;
            int day;
            
            Function.Input(out year, out month, out day);
            Date date = new Date(year, month, day);

            Console.WriteLine(date.ToString());
            int insexOfDay = (int)date.getDayOfWeek();
            Console.WriteLine(Date.valueOf(insexOfDay));

            Console.WriteLine("\nВведите ещё одну дату, чтобы рассчитать количество дней, в заданном временном промежутке");
            Function.Input(out year, out month, out day);
            Date date1 = new Date(year, month, day);
            Console.WriteLine(date1.ToString());
            Console.WriteLine($"Количесто дней: {date.daysBetween(date1)}");

            Console.WriteLine($"\nРавны ли даты: {date.Equals(date1)}");

        }
	}
}
