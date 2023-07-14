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
        [Route("{name}")]
        public IEnumerable<Product> Get(string name)
        {
            return new RequestHandler(context).Read(name);
        }

        [HttpPost]
        [Route("{product}")]
        public void Post(Product product) 
        {
            new RequestHandler(context).Create(product);
        }
    }
}
