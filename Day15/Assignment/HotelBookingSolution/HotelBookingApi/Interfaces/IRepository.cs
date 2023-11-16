namespace HotelBookingApi.Interfaces
{
    public interface IRepository<K,T>
    {
        T GetById(K id);
        IList<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(K id);
    }

}
