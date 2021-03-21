using System.Collections.Generic;
using Interfaces;

namespace Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();

        public void Delete(int id)
        {
            serieList[id].Delete();
        }

        public void Insert(Serie serie)
        {
            serieList.Add(serie);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Serie ReturnById(int id)
        {
            return serieList[id];
        }

        public void Update(int id, Serie serie)
        {
            serieList[id] = serie;
        }
    }
}