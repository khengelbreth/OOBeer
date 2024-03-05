using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOBeer
{
    public class BeersRepository 
    { 
        private int _nextId = 5;
        private List<Beer> _beers = new()
        {
            new Beer { Id = 1, Name = "1664 Blanc", Abv = 6.4 },
            new Beer { Id = 2, Name = "Tuborg Julebryg", Abv = 6 },
            new Beer { Id = 3, Name = "Carlsberg Classic", Abv = 4.7 },
            new Beer { Id = 4, Name = "Guiness Stout", Abv = 5 },
            new Beer { Id = 5, Name = "Nissefars Sure Sokker", Abv = 13 }
        };
        public IEnumerable<Beer> GetBeers(double? minAbvFilter = null, double? maxAbvFilter = null, string? inName = null, string? orderBy = null)
        {
            if (minAbvFilter != null)
            {
                if (maxAbvFilter != null)
                {
                    return _beers.Where(b => b.Abv <= maxAbvFilter);
                }
                return _beers.Where(b => b.Abv >= minAbvFilter);

            }
            if (inName != null)
            {
                return _beers.Where(b => b.Name.Contains(inName));
            }
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "name":
                        _beers.OrderBy(b => b.Name);
                        break;
                    case "name_desc":
                        _beers.OrderByDescending(b => b.Name);
                        break;
                    case "abv":
                        _beers.OrderBy(b => b.Abv);
                        break;
                    case "abv_desc":
                        _beers.OrderByDescending(b => b.Abv);
                        break;
                    default:
                        break;
                }
            }
            return new List<Beer>(_beers);
        }

        public Beer? GetBeerById(int id)
        {
            return _beers.Find(b => b.Id == id);
        }

        public Beer AddBeer(Beer beer)
        {
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = _beers.Find(b => b.Id == id);
            if (beer != null)
            {
                _beers.Remove(beer);
            }
            return beer;
        }

        public Beer? UpdateBeer(int id, Beer data)
        {
            Beer? beerToUpdate = _beers.Find(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = data.Name;
                beerToUpdate.Abv = data.Abv;
            }
            return beerToUpdate;
        }

        public override string ToString()
        {
            return string.Join($",\n", _beers);
        }
    }
}

