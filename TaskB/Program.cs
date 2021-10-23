using System;

namespace TaskB
{
    //4. Шеф-повар.Определить иерархию овощей.Сделать салат.
    //Подсчитать калорийность.Провести сортировку овощей для 
    //салата на основе одного из параметров. Найти овощи в салате, 
    //соответствующие заданному диапазону калорийности.

    class Program
    { 
        static void Main(string[] args)
        {
            Salad salad = new Salad();
            
            Console.WriteLine("--Сделайте салат из следующих ингридиентов--");
            salad.DisplayNames();

            Console.WriteLine("\n--Введите сколько грамм овощей Вы хотите добавить--");
            salad.SetWeight();

            Console.WriteLine($"Каллорийность салата: {salad.CalorieCounting()} ккал");

            Console.WriteLine("\nОвощи отсортированы по количеству каллорий в порядке возрастания: ");
            salad.SortByCalorie();
            salad.OutputSortedVegetables();

            Console.Write("\nВведите первое значение каллорийности: ");
            double value1 = double.Parse(Console.ReadLine());
            Console.Write("Введите второе значение каллорийности: ");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nОвощи в салате, соответствующие заданному диапазону калорийности: ");
            salad.SearchByCalorieRange(value1, value2);

        }
    }
}
