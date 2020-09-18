using System.Collections.Generic;
using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book : NamedObject
    {
        //constructor
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;

        }
        //method

        public void AddGrade(char letter)

        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(32);
                    break;
                case 'C':
                    AddGrade(33);
                    break;
                //optional - we can also leave it without it adn in that case
                //if no letter will match - no case will be executed.
                default:
                    AddGrade(0);
                    break;
            }

        }
        public void AddGrade(double grade)
        {

            if (grade <= 100 && grade >= 0)

            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());

                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public Statistic GetStatistic()
        {
            var result = new Statistic();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            //var index = 0;
            for (var index = 0; index < grades.Count; index += 1)
            {

                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);

                result.Average += grades[index];
            }

            result.Average /= grades.Count;
            switch (result.Average)
            {
                case var d when d >= 25:
                    result.Letter = 'A';
                    break;
                case var d when d >= 20:
                    result.Letter = 'B';
                    break;
                case var d when d >= 15:
                    result.Letter = 'C';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }
            return result;

        }



        //fields
        private List<double> grades;

        public const string CATEGORY = "Science";

        //event
        public event GradeAddedDelegate GradeAdded;


    }

}