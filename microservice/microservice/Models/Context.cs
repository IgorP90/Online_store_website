namespace microservice.Models
{
    public class Context
    {
        public string ConnectionString { get; }
        public Context(string connectionString) => this.ConnectionString = connectionString;
    }
}
