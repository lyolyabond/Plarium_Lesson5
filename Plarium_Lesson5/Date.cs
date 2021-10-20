using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
     class Date
        {
            Year yearClass;
            Month monthClass;
            Day dayClass;
            //Композиция (создание объектов классов в конструкторе)
            //В конструкторе задаётся дата
            public Date(int year, int month, int day)
            {
                yearClass = new Year(year);
                monthClass = new Month(month);
                dayClass = new Day(day);
            }
        //Метод получения дня недели по дате
        //Алгоритм определения дня недели взят из интернет-ресурсов
            public DayOfWeek getDayOfWeek()
            {
                int monthCode = monthClass.MonthNumber switch
                {
                    1 => 1,
                    10 => 1,
                    5 => 2,
                    8 => 3,
                    2 => 4,
                    3 => 4,
                    11 => 4,
                    6 => 5,
                    12 => 6,
                    9 => 6,
                    4 => 0,
                    7 => 0,
                    _ => -1
                };
                int lastTwoDigits = yearClass.YearNumber % 100;
                int yearCode = (6 + lastTwoDigits + lastTwoDigits / 4) % 7;
                int day = (dayClass.DayNumber + monthCode + yearCode) % 7;
                if (yearClass.LeapYear && (monthClass.MonthNumber == 1 || monthClass.MonthNumber == 2))
                {
                    day--;
                    if (day == -1)
                        day = 6;
                }
                    return (DayOfWeek)(day);
            }
        //Метод вычисления количества дней от начала года
            public int getDayOfYear()
            {
                int day = 0;
                for (int i = 1; i < monthClass.MonthNumber; i++)
                {
                    day += monthClass.getDays(i, yearClass.LeapYear);
                }
                day += dayClass.DayNumber;
                return day;
            }
        //Метод вычисления количество дней, в заданном временном промежутке
        public int daysBetween(Date date)
            {
                if(yearClass.YearNumber > date.yearClass.YearNumber)
                {
                    return DaysCounting(date, this);

                }
                else if (yearClass.YearNumber < date.yearClass.YearNumber)
                {
                    return DaysCounting(this, date);
                } 
                else return Math.Abs(this.getDayOfYear() - date.getDayOfYear());
            }
        //Вспомогательный метод для daysBetween()
        int DaysCounting(Date date1, Date date2)
            {
                int days = 0;
                //Расчёт целых лет между годами, выражение в днях
                    for (int i = date1.yearClass.YearNumber + 1; i < date2.yearClass.YearNumber; i++)
                    {
                //Если случался высокосный год, за этот промежуток времени 
                        if (i % 4 == 0)
                        {
                            days += 366;
                        }
                        else days += 365;
                    }
                    //Вычисление количества дней от начала года(последняя дата) и от конца(другая дата)
                    days += date2.getDayOfYear() + (365 - date1.getDayOfYear());
            //Добавление ещё одного дня, если год - высокосный
                    if (yearClass.LeapYear) days++;
                
                return days;
            }
        //Метод, который возвращает название дня недели по индексу 
        public static DayOfWeek valueOf(int index)
            {
                return (DayOfWeek)index;
            }
        //Вложенный класс
             class Year
            {
                public int YearNumber { get; }
                public bool LeapYear { get;}
            //Конструктор класса, в котором дополнительно определяется, высокосный год или нет
                public Year(int year)
                {
                    YearNumber = year;
                    if (YearNumber % 4 == 0)
                        LeapYear = true;
                    else LeapYear = false;
                }
            }
        //Вложенный класс
        class Month
            {
                public int MonthNumber { get; }
                public Month(int month)
                {
                    MonthNumber = month;
                }
            //Метод, который позволяет узнать количество дней для того или иного месяца
            public int getDays(int monthNumber, bool leapYear)
                {
                    switch (monthNumber)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            return 31;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            return 30;
                        case 2:
                            if (leapYear)
                                return 29;
                            else return 28;
                        default: return -1;
                    }
                }
            }
        //Вложенный класс
        class Day
            {
                public int DayNumber { get; }
                public Day(int day)
                {
                    DayNumber = day;
                }

            }
        //Перечисление дней недели (порядок соответствует индексу дня неделя в методе getDayOfWeek)
        public enum DayOfWeek
            {
                Saturday,
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday
                
            }
        //Переопределение метода ToString() 
        public override string ToString() 
            {
                return $"Дата: {dayClass.DayNumber}.{monthClass.MonthNumber}.{yearClass.YearNumber}";
            }
        //Переопределение метода Equals() 
        public override bool Equals(object obj)
            {
                if (obj == null || !this.GetType().Equals(obj.GetType()))
                    return false;
                else
                { 
                Date date = (Date)obj; 

                return date.yearClass.YearNumber == yearClass.YearNumber
                    && date.monthClass.MonthNumber == monthClass.MonthNumber
                    && date.dayClass.DayNumber == dayClass.DayNumber;
                }
            }
      }
}
