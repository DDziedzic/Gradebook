using System;
using Xunit;

namespace GradeBook.Tests
{

    public class TypeTests
    {
        int count = 0;
        public delegate string WriteLogDelegate(string logMessage);

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello");

            Assert.Equal(3, count);
        }


        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void GetBooksReturnDifferentObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwoVariablesCanRefferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }
        [Fact]
        public void CanSetNameForRefference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpCanPassByReff()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        void GetBookSetNameRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        [Fact]
        public void ValuesTypesAreAlsoPassByValue()
        {
            var x = GetInt();
            SetIn(x);
            Assert.Equal(3, x);
        }

        //- the result of the following code will still be 3.
        // as you are always passing the value not the refference. 
        //So - you are really passing value 3 to the SetIn() method. 
        void SetIn(int x)
        {
            x = 5;
        }

        int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ValuesTypesCanPassByValue()
        {
            var x = GetInt();
            SetIn(ref x);
            Assert.Equal(5, x);
        }

        void SetIn(ref int x)
        {
            x = 5;
        }

        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            var name = "Scott";
            var upperCase = MakeUpperCase(name);
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upperCase);

        }

        string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        // [Fact]
        // public void AddGradeMethodValidatesValue()
        // {
        //     var book1 = GetBook("Book 1");
        //     var x = 105;
        //     var y = 99;
        //     book1.AddGrade(x);
        //     book1.AddGrade(y);
        //     var b = book1.grades;
        //     Assert.DoesNotContain(x, b);
        //     // Assert.Empty(b);
        // }


    }
}
