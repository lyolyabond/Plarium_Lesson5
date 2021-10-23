using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    public class Salad 
    {
        //Создание массива объектов
        AbstractClass.Vegetable[] arrayOfVegetables = new AbstractClass.Vegetable[] 
        {new Vegetables.Tomato(), new Vegetables.Cucumber(), new Vegetables.Pepper(),
         new Vegetables.Cabbage(),new Vegetables.Onion() };

        //Метод вывода имён овощей
        public void DisplayNames()
        {
            foreach(var vegetable in arrayOfVegetables)
            {
                vegetable.DisplayVegetableName();
            }
        }
        //Метод установки веса овоща 
        public void SetWeight()
        {
            foreach (var vegetable in arrayOfVegetables)
            {
                //Показ названия овоща
                vegetable.DisplayVegetableName();
                //Установка веса
                vegetable.Weight = int.Parse(Console.ReadLine());
                //Подсчёт каллорий в соответсвии с весом
                vegetable.Calories = vegetable.CalorieCounting();
            }
        }
        //Метод подсчёта каллорий салата 
        public double CalorieCounting()
        {
            double calories = 0;
            //Calories - это уже расчитанное значение в соответсвии с весом
            foreach (var vegetable in arrayOfVegetables)
            calories += vegetable.Calories;
            return calories;
        }
        
        //Метод сортировки овощей по значению каллорий
        public void SortByCalorie()
        {
            //Вызов метода сортировки Sort() с использованием указанного IComparer
            Array.Sort(arrayOfVegetables, new CaloriesComparer());   
        }
        //Метод вывода информации об отсортированном по значению каллорий массиве объектов
        public void OutputSortedVegetables()
            {
                foreach (var vegetable in arrayOfVegetables)
                {
                    Console.Write($"{vegetable.Calories}\t");
                }
                Console.WriteLine();
                foreach (var vegetable in arrayOfVegetables)
                {
                    Console.Write($"{vegetable.VegetableName}\t");
                }
            }
        //Метод поиска овощей в салате, соответствующих заданному диапазону калорийности
        public void SearchByCalorieRange(double value1, double value2)
        {
            bool flag = false;
            foreach(var vegetable in arrayOfVegetables)
            {
                if (value1 >= value2)
                {
                    //Сравнение значений
                    if (vegetable.Calories <= value1 && vegetable.Calories >= value2)
                    {
                        //Вывод названий овощей
                        vegetable.DisplayVegetableName();
                        flag = true;
                    }    
                }
                else
                {
                    //Сравнение значений
                    if (vegetable.Calories >= value1 && vegetable.Calories <= value2)
                    {
                        //Вывод названий овощей
                        vegetable.DisplayVegetableName();
                        flag = true;
                    }
                }               
            }
            if(!flag) Console.WriteLine("Нет овощей в заданом диапазоне калорий!");


        }
    }
}
