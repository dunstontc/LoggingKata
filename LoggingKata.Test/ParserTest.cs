using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldReturnNullForEmptyString()
        {
            const string emptyString = "";
            var res = TacoParser.Parse(emptyString);
            Assert.Null(res);
        }
        
        [Test]
        public void ShouldReturnNullForNullString()
        {
            const string nullString = null;
            var res = TacoParser.Parse(nullString);
            Assert.Null(res);
        }

        [Test]
        public void ShouldParseLine()
        {
            const string testString = "-84.460905, 34.466038,\"Jaspe... \"";
            var res = TacoParser.Parse(testString);
            Assert.IsNotNull(res);
        }

        [Test]
        public void ShouldReturnNullForInvalidNumbers()
        {
            const string testString = "-84.460905, \"Jaspe... \"";
            var res = TacoParser.Parse(testString);
            Assert.Null(res);
        }

        // TODO: Test for valid number values with no description.
    }
}



