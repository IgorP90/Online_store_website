using backend.CRUD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace backend.Models
{
    public class DBPlaceholder
    {
        public IEnumerable<NarrowCategory> FillDB()
        {
            return JSONDeserializer.JSONDeserializ<NarrowCategory>("NarrowCategories.json");
        }
    }
}
