using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<T> ReadRow<T>(int id) where T : class, IId
        {
            return (await context.Set<T>().Where(i => i.Id == id).ToListAsync()).First();
        }

        public IEnumerable<T> ReadRow<T>(string name) where T : class, IName
        {
            return context.Set<T>().Where(n => EF.Functions.Like(n.Name, $"%{name}%")).Take(10); 
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
