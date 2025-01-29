using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace backend.CRUD
{
    public class Read
    {
        private readonly Context context;
        private readonly IDistributedCache cache;

        public Read(Context context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public IEnumerable<T> ReadRow<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> ReadRow<T>(int id) where T : class, IProduct
        {
            try
            {
                string searchResult = cache.GetString(id.ToString());
                if (searchResult.IsNullOrEmpty())
                {
                    Thread.Sleep(2000);
                    T data = context.Set<T>().Where(i => i.Id == id).ToList().First();
                    searchResult = JsonSerializer.Serialize(data);
                    cache.SetStringAsync(data.Id.ToString(), searchResult, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    });
                    return data;
                }
                return JsonSerializer.Deserialize<T>(searchResult);
            }
            catch
            {
                return context.Set<T>().Where(i => i.Id == id).ToList().First();
            }
        }

        public IEnumerable<T> ReadRow<T>(string name) where T : class, IProduct
        {
            return context.Set<T>().Where(n => EF.Functions.Like(n.Name, $"%{name}%")).Take(10); 
        }

        public IEnumerable<T> ReadRowByNarrowCategory<T>(string name) where T : class, INarrowCategory
        {
            return context.Set<T>().Where(n => n.NarrowCategory.Name == name);
        }

        public IEnumerable<T> ReadRowByWideCategory<T>(string name) where T : class, IProduct, IWideCategory
        {
            //return context.Set<T>().Include(q => q.WideCategories).FirstOrDefault(w=>w.WideCategories)

            //return context.Set<T>().Include(n => n.WideCategories.Where(r=>r.Name==name).ToList);
            //return context.Set<T>().SelectMany(n => n.WideCategories.ForEach((p=> Product));
            //return context.Set<T>().Where(n=>n.WideCategories.Where(f=>f.Name==name).ToList();
            return context.Set<T>().Include(a => a.WideCategories);
        }
    }
}
