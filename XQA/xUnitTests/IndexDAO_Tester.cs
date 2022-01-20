using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Xunit;
using FluentAssertions;
using XQA.DAL;

namespace XQA.xUnitTests
{
    public class IndexDAO_Tester
    {
        public IndexDAO iDAO = new IndexDAO();

        [Theory]
        [InlineData(1)]
        public void findNumberOfDocumentsByTermIdUsingLinq_Test(int expected)
        {
            var actual = iDAO.findNumberOfDocumentsByTermIdUsingLinq(2);

            //xUnit 
            Assert.Equal(expected, actual);

            //fluent 
            //actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(findNumberOfDocumentsByTermIdUsingLambda))]
        public void findNumberOfDocumentsByTermIdUsingLambda_Test(int termID)
        {
            int expected = 2;
            int actual = iDAO.findNumberOfDocumentsByTermIdUsingLambda(termID);

            //xUnit 
            //Assert.Equal(expected, actual);

            //fluent 
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1)]
        public void findTotalNumberOfOccurencesByTermId_Test(int termId)
        {
            int expected = 3;
            int actual = iDAO.findTotalNumberOfOccurencesByTermId(termId);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> findNumberOfDocumentsByTermIdUsingLambda(int termID)
        {
            IndexDAO iDAO = new IndexDAO();
            return new List<object[]> 
            {
                new object[] { iDAO.findNumberOfDocumentsByTermIdUsingLambda(termID) } 
            };
        }
    }
}
