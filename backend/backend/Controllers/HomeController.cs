using backend.CRUD;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly Context context;

        public HomeController(Context context) => this.context = context;

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new RequestHandler(context).Read();
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Product> Get(int id)
        {
            return new RequestHandler(context).Read(id);
        }

        [HttpPost]
        [Route("{product}")]
        public void Post(Product product) 
        {
            new RequestHandler(context).Create(product);
        }
    }
}
