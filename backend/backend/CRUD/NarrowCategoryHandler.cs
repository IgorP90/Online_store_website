using backend.Models;

namespace backend.CRUD
{
    public class NarrowCategoryHandler
    {
        private readonly Context context;
        public NarrowCategoryHandler(Context context) => this.context = context;

        public IEnumerable<NarrowCategory> Read()
        {
            return context.NarrowCategories;
        }
        public void Create(NarrowCategory narrowCategory)
        {
            context.Add(narrowCategory);
            context.SaveChanges();
        }
    }
}
