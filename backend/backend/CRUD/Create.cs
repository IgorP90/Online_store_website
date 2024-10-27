using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.CRUD
{
    public class Create 
    {
        private readonly Context context;

        public Create(Context context) => this.context = context;

        public void CreateRow <T> (T model) where T : class
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

               
            }
            
        }
    }
}
