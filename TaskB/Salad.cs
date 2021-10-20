using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    public class Salad
    {
         double calories;
         Vegetables.Tomato tomato;
         Vegetables.Cucumber cucumber;
         Vegetables.Pepper pepper;
         Vegetables.Cabbage cabbage;
         Vegetables.Onion onion;
        //Агрегация
        //В конструктор передаётся уже существующий объект
        public Salad(Vegetables.Tomato tomato,
        Vegetables.Cucumber cucumber,
        Vegetables.Pepper pepper,
        Vegetables.Cabbage cabbage,
        Vegetables.Onion onion)
        {
            this.tomato = tomato;
            this.cucumber = cucumber;
            this.pepper = pepper;
            this.cabbage = cabbage;
            this.onion = onion;
        }
        //Метод подсчёта каллорий салата 
        public double CalorieCounting()
        {
            //Calories - это уже расчитанное значение связанное с весом
            calories = tomato.Calories + cucumber.Calories + pepper.Calories + cabbage.Calories + onion.Calories;
            return calories;
        }
        //Метод сортировки овощей по значению каллорий
        public AbstractClass.Vegetable[] SortByCalorie()
        {
            //Создание массива объектов
            AbstractClass.Vegetable[] arrayOfVegetables = new AbstractClass.Vegetable[] { tomato, cucumber, pepper, cabbage, onion };
            object temp;
            //Пузырькова сортировка объектов по значению Calories
            for (int i = 0; i < arrayOfVegetables.Length - 1; i++)
            {
                for(int j = i+1; j < arrayOfVegetables.Length; j++)
                {
                    if(arrayOfVegetables[i].Calories > arrayOfVegetables[j].Calories)
                    {
                        temp = arrayOfVegetables[i];
                        arrayOfVegetables[i] = arrayOfVegetables[j];
                        arrayOfVegetables[j] = (AbstractClass.Vegetable)temp;
                    }
                }    
            }
            return arrayOfVegetables;
        }
        //Метод вывода информации об отсортированном по значению каллорий массиве объектов
        public void OutputSortedVegetables(AbstractClass.Vegetable[] arrayOfVegetables)
            {
                foreach (var value in arrayOfVegetables)
                {
                    Console.Write($"{value.Calories}\t");
                }
                Console.WriteLine();
                foreach (var value in arrayOfVegetables)
                {
                    Console.Write($"{value.VegetableName}\t");
                }
            }
        //Метод поиска овощей в салате, соответствующих заданному диапазону калорийности
        public void SearchByCalorieRange(double value1, double value2, AbstractClass.Vegetable[] arrayOfVegetables)
        {
            bool flag = false;
            foreach(var vegetables in arrayOfVegetables)
            {
                if (value1 >= value2)
                {
                    //Сравнение значений
                    if (vegetables.Calories <= value1 && vegetables.Calories >= value2)
                    {
                        //Вывод названий овощей
                        vegetables.DisplayVegetableName();
                        flag = true;
                    }    
                }
                else
                {
                    //Сравнение значений
                    if (vegetables.Calories >= value1 && vegetables.Calories <= value2)
                    {
                        //Вывод названий овощей
                        vegetables.DisplayVegetableName();
                        flag = true;
                    }
                }               
            }
            if(!flag) Console.WriteLine("Нет овощей в заданом диапазоне калорий!");


        }
    }
}
