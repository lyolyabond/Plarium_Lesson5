using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    public class Vegetables
    {
        //Классы определённых овощей - наследников абстрактного класса
        public class Tomato : AbstractClass.Vegetable 
        {
            //переопределение базовых свойств
            public override string VegetableName => "Помидор";
            public override double CalorieContent => 18;

        }
        public class Cucumber : AbstractClass.Vegetable
        {
            public override string VegetableName => "Огурец";
            public override double CalorieContent => 16;
        }
        public class Pepper : AbstractClass.Vegetable
        {
            public override string VegetableName => "Перец";
            public override double CalorieContent => 26;
        }

        public class Cabbage : AbstractClass.Vegetable
        {
            public override string VegetableName => "Капуста";
            public override double CalorieContent => 25;
        }
        public class Onion : AbstractClass.Vegetable
        {
            public override string VegetableName => "Лук";
            public override double CalorieContent => 40;
        }

    }
}
