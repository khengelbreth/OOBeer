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
    public class BeersRepositoryTests
    {
        private BeersRepository _repo;

        [TestInitialize]
        public void Initialize() 
        { 
            _repo = new BeersRepository(); 
        }
        
        [TestMethod()]
        public void GetBeersTest()
        { 
            IEnumerable<Beer> beers  = _repo.GetBeers();

            Assert.IsTrue(beers.Any());
            Assert.AreEqual(5,beers.Count());
        }

        [TestMethod()]
        public void AddBeerTest()
        {
            Beer grapeBeer = new Beer() { Id = 6, Name = "Grape Infusion", Abv = 10.4 };
            _repo.AddBeer(grapeBeer);

            Assert.IsTrue(_repo.GetBeers().Contains(grapeBeer));
            Assert.AreEqual(6,_repo.GetBeers().Count());
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            Beer removableBeer = new Beer() { Name = "Honest Deletable", Abv = 7 };

            _repo.AddBeer(removableBeer);

            Assert.IsTrue(_repo.GetBeers().Contains(removableBeer));
            Assert.AreEqual(5, removableBeer.Id);
            Assert.AreEqual(6, _repo.GetBeers().Count());

            var deletedBeer = _repo.DeleteBeer(removableBeer.Id);

            Assert.AreEqual(5, _repo.GetBeers().Count());
            Assert.IsFalse(_repo.GetBeers().Contains(deletedBeer));
        }
    }
}