using System.Collections.Generic;
using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {

        //constructor
        public InMemoryBook(string name) : base(name)
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
        public override void AddGrade(double grade)
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
        public override Statistic GetStatistic()
        {
            var result = new Statistic();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);

            }
            return result;

        }


        //fields
        private List<double> grades;

        //event
        public override event GradeAddedDelegate GradeAdded;


    }

}