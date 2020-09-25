namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistic GetStatistic();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistic GetStatistic();

        public const string CATEGORY = "Science";

    }

}