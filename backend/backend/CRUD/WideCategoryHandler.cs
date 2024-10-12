using backend.Models;

namespace backend.CRUD
{
    public class WideCategoryHandler
    {
        private readonly Context context;
        public WideCategoryHandler(Context context) => this.context = context;

        public IEnumerable<WideCategory> Read()
        {
            return context.WideCategories;
        }

        public IEnumerable<WideCategory> Read(string name) 
        {
             return context.WideCategories.Where(n => n.Name == name);
        }

        public void Create(WideCategory wideCategory) 
        {
            IEnumerable<WideCategory> wc = context.WideCategories.Where(n => n.Name == wideCategory.Name);
            if (wc.Count() == 0) 
            {
                context.Add(wideCategory);
                context.SaveChanges();
            }
        }

        public void Test_1(Test test)
        {
            context.Add(test);
            context.SaveChanges();
        }
    }
}
