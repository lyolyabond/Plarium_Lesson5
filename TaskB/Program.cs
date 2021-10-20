using System;

namespace TaskB
{
    //4. Шеф-повар.Определить иерархию овощей.Сделать салат.
    //Подсчитать калорийность.Провести сортировку овощей для 
    //салата на основе одного из параметров. Найти овощи в салате, 
    //соответствующие заданному диапазону калорийности.

    class Program
    { 
        //Статический метод ввода информации об объектах
        static void Input(Vegetables.Tomato tomato, Vegetables.Cucumber cucumber, Vegetables.Pepper pepper,
            Vegetables.Cabbage cabbage, Vegetables.Onion onion)
        {
            Console.WriteLine("--Сделайте салат из следующих ингридиентов--");
            Console.WriteLine($"{tomato.VegetableName}\t{cucumber.VegetableName}\t{pepper.VegetableName}\t" +
                $"{cabbage.VegetableName}\t{onion.VegetableName}");

            Console.WriteLine("--Введите сколько грамм овощей Вы хотите добавить--");
            tomato.DisplayVegetableName();
            tomato.Weight = int.Parse(Console.ReadLine());
            tomato.Calories = tomato.CalorieCounting();

            cucumber.DisplayVegetableName();
            cucumber.Weight = int.Parse(Console.ReadLine());
            cucumber.Calories = cucumber.CalorieCounting();

            pepper.DisplayVegetableName();
            pepper.Weight = int.Parse(Console.ReadLine());
            pepper.Calories = pepper.CalorieCounting();

            cabbage.DisplayVegetableName();
            cabbage.Weight = int.Parse(Console.ReadLine());
            cabbage.Calories = cabbage.CalorieCounting();

            onion.DisplayVegetableName();
            onion.Weight = int.Parse(Console.ReadLine());
            onion.Calories = onion.CalorieCounting();
        }

        static void Main(string[] args)
        {
            Vegetables.Tomato tomato = new Vegetables.Tomato();
            Vegetables.Cucumber cucumber = new Vegetables.Cucumber();
            Vegetables.Pepper pepper = new Vegetables.Pepper();
            Vegetables.Cabbage cabbage = new Vegetables.Cabbage();
            Vegetables.Onion onion = new Vegetables.Onion();
            Input(tomato, cucumber, pepper, cabbage, onion);
            
            Salad salad = new Salad(tomato, cucumber, pepper, cabbage, onion);
            Console.WriteLine($"Каллорийность салата: {salad.CalorieCounting()} ккал");

            Console.WriteLine("\nОвощи отсортированы по количеству каллорий в порядке возрастания: ");
            
            AbstractClass.Vegetable[] arrayOfVegetables = salad.SortByCalorie();
            salad.OutputSortedVegetables(arrayOfVegetables);

            Console.Write("\nВведите первое значение каллорийности: ");
            double value1 = double.Parse(Console.ReadLine());
            Console.Write("Введите второе значение каллорийности: ");
            double value2 = double.Parse(Console.ReadLine());
            Console.WriteLine("\nОвощи в салате, соответствующие заданному диапазону калорийности: ");
            salad.SearchByCalorieRange(value1, value2, arrayOfVegetables);

        }
    }
}
