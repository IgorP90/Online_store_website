using backend.Models;

namespace backend.CRUD
{
    public class Create 
    {
        private readonly Context context;

        public Create(Context context) => this.context = context;

        public async Task CreateRow <T> (T model) where T : class
        {
            context.Add(model);
            context.SaveChanges();
        }
    }
}
