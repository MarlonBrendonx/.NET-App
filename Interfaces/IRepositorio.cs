namespace APP_SERIES.Interfaces
{
    public interface IRepositorio<T>{

        List<T> listSeries();
        T getById(int id);
        void set(T entidade);
        void remove(int id);
        void update(int id, T entidade);
        int nextId();

    }

}