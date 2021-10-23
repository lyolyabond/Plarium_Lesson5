using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    //Компаратор объектов AstractClass.Vegetable
    class CaloriesComparer : IComparer<AbstractClass.Vegetable>
    {
        
        public int Compare(AbstractClass.Vegetable vegetable1, AbstractClass.Vegetable vegetable2)
        {
            //Cравнивает объекты в зависимости от значения каллорийности
            return vegetable1.Calories.CompareTo(vegetable2.Calories);
        }
    }    
}
