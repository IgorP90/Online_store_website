using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.CRUD
{
    public class Read
    {
        private readonly Context context;

        public Read(Context context) => this.context = context;

        public IEnumerable<T> ReadRow<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> ReadRow<T>(int id) where T : class, IId
        {
            return context.Set<T>().Where(i => i.Id == id);
        }

        public IEnumerable<T> ReadRow<T>(string name) where T : class, IName
        {
            try
            {
                return context.Set<T>().Where(n => EF.Functions.Like(n.Name, $"%{name}%")).Take(10);
            }
            catch (Exception)
            {

                return null;
            }  
        }

        public IEnumerable<T> ReadRowByNarrowCategory<T>(string name) where T : class, INarrowCategory
        {
            return context.Set<T>().Where(n => n.NarrowCategory.Name == name);
        }

        public IEnumerable<T> ReadRowByWideCategory<T>(string name) where T : class, IWideCategory
        {
            //return context.Set<T>().Include(q => q.WideCategories).FirstOrDefault(w=>w.WideCategories)
            //return context.Set<T>().Where(n => n.WideCategories.Name == name);
            return null;
        }
    }
}
