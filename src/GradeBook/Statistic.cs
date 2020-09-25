using System.Collections.Generic;
using System;
namespace GradeBook
{

    public class Statistic
    {

        public Statistic()
        {

            High = double.MinValue;
            Low = double.MaxValue;
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 25:
                        return 'A';

                    case var d when d >= 20:
                        return 'B';

                    case var d when d >= 15:
                        return 'C';

                    default:
                        return 'F';
                }

            }
        }
        public double Sum;
        public int Count;



        public void Add(double number)
        {
            Sum += number;
            Count += 1;

            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }



    }
}