using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOBeer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBeer.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer goodBeerName = new Beer() { Id = 1, Name = "PaaskeBryg", Abv = 4.6 };
            Beer badBeerName = new Beer() { Id = 2, Name = "Øl", Abv = 1 };
            Beer nullBeerName = new Beer() { Id = 3, Abv = 22 };
            Beer limitBeerName = new Beer() { Id = 4, Name = "Oel", Abv = 88 };

            goodBeerName.ValidateName();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => badBeerName.ValidateName());
            Assert.ThrowsException<ArgumentNullException>(() => nullBeerName.ValidateName());
            limitBeerName.ValidateName();
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer goodBeerAbv = new Beer() { Id = 1, Name = "Oel", Abv = 6 };
            Beer badBeerAbv = new Beer() { Id = 2, Name = "JuleOel", Abv = -1 };
            Beer limitBeerTest = new Beer() { Id = 3, Name = "James' Easter Beer", Abv = 0 };
            Beer limitBeerTest2 = new Beer() { Id = 4, Name = "James' Easter Beer 2.0", Abv = 67 };
            Beer limitBeerTest3 = new Beer() { Id = 5, Name = "M", Abv = 0.1 };

            goodBeerAbv.ValidateAbv();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => badBeerAbv.ValidateAbv());
            limitBeerTest.ValidateAbv();
            limitBeerTest2.ValidateAbv();
            limitBeerTest3.ValidateAbv();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Beer beer = new Beer() { Id = 1, Name = "Frederikke Oel", Abv = 8 };
            string beerString = beer.ToString();

            Assert.AreEqual("1, Frederikke Oel, 8",beerString);
        }
    }
}