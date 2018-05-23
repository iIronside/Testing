using NUnit.Framework;
using Moq;
using MySqlQueryPreparator;


namespace SqlQueryPreparatorTests.Tests
{
    [TestFixture]
    public class SqlQueryPreparatorTests
    {
        private readonly Mock<ISafeString> dummySafeStr = new Mock<ISafeString>();

        string[] testStrs = {"fake str1", "fake str2", "fake str3" };

        [Test]
        public void PrepareQueries_fakeStr_useSafeString()
        {
            SqlQueryPreparator sqlQPreparator = new SqlQueryPreparator(dummySafeStr.Object);

            sqlQPreparator.PrepareQueries(testStrs);
            
            dummySafeStr.Verify(d => d.SafeString(It.IsAny<string>()),Times.AtLeast(testStrs.Length));
        }
    }
}
