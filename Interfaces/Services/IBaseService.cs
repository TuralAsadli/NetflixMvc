namespace Interfaces.Services
{
    public interface IBaseService<VM> where VM : class
    {
        void Create(VM item);
        VM FindById(int id);
        IEnumerable<VM> GetAll();

        void Remove(int id);
        void Update(int id,VM item);
        IEnumerable<VM> GetWithId();
    }
}
