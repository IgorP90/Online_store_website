namespace microservice.Models
{
    public interface IDBHandler
    {
        void Create(User user);
        string Read(int id);
        void Update();
        void Delete();

    }
}
