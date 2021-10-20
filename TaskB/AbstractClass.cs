using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    public class AbstractClass
    {
        //Интерфейс определяющий методы для абстрактного класса 
         interface IVegetable 
        {
            void DisplayVegetableName();
            double CalorieCounting();

        }

        //Абстрактный класс овоща
            public abstract class Vegetable : IVegetable
        {
            //Автосвойства
            public virtual string VegetableName
            {
                get; 
            }
            public virtual double CalorieContent
            {
                get; 
            }
            public virtual double Weight
            {
                get; set;
            }
            public virtual double Calories
            {
                get; set;
            }
            //Реализация методов
            public void DisplayVegetableName()
            {
                Console.Write($"{VegetableName}\t");
            }
            public double CalorieCounting() =>  Weight * CalorieContent/100;
        }
    }
}
