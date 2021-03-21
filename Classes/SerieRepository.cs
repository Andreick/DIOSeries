using System.Collections.Generic;
using Interfaces;

namespace Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();

        public void Delete(int id)
        {
            
        }

        public void Insert(Serie entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Serie> List()
        {
            throw new System.NotImplementedException();
        }

        public int NextId()
        {
            throw new System.NotImplementedException();
        }

        public Serie ReturnById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Serie serie)
        {
            serieList[id] = serie;
        }
    }
}