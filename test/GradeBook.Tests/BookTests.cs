using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(13.3);
            book.AddGrade(22.3);
            book.AddGrade(23.3);
            //act
            var result = book.GetStatistic();
            //assert

            Assert.Equal(23.3, result.High, 1);
            Assert.Equal(13.3, result.Low, 1);
            Assert.Equal(19.6, result.Average, 1);
            Assert.Equal('C', result.Letter);
        }
    }
}
