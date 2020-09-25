using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            IBook book = new DiskBook("My GradeBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            book.GetStatistic();
            var stats = book.GetStatistic();
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The category is {DiskBook.CATEGORY}");
            Console.WriteLine($"The avg number is {stats.Average:N1}!");
            Console.WriteLine($"The max number is {stats.High}!");
            Console.WriteLine($"The min number is {stats.Low}!");
            Console.WriteLine($"The letter is {stats.Letter}!");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Insert the grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)

                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("If no warning printed - grade added");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("The event was handled");

        }

    }

}
