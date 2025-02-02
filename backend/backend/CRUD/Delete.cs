using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

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
                context.RemoveRange(context.Set<T>().Where(i => i.Id == id));
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }  
        }
    }
}
