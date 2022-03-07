using APP_SERIES.Interfaces;

namespace APP_SERIES.Models
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        List<Serie> listaserie = new List<Serie>();

        public Serie getById(int id)
        {
            return listaserie[id];
        }

        public List<Serie> listSeries()
        {
            return listaserie;
        }

        public int nextId()
        {
            return listaserie.Count();
        }

        public void remove(int id)
        {
            listaserie[id].remove();
        }

        public void set(Serie entidade)
        {
            listaserie.Add(entidade);
        }

        public void update(int id, Serie entidade)
        {
            listaserie[id] = entidade;
        }
    }
}