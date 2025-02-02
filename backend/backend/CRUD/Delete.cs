using backend.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.CRUD
{
    public class Delete
    {
        private readonly Context context;

        public Delete(Context context) => this.context = context;

        public void DeleteRow<T>(int id) where T : class, IProduct
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();

            try
            {
                context.RemoveRange(context.Set<T>().Find(id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }  
        }
    }
}
