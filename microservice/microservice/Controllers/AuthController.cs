using microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Context context;

        public AuthController(Context context) => this.context = context;

        [HttpPost]
        [Route("postuser")]
        public void CreateUser(User user) //-
        {
            new CRUDHandler(context).Create(user);
        }

        [HttpGet]
        [Route("getuser/{id}")]
        public string ReadUser(int id)
        {
            return new CRUDHandler(context).Read(id);
        }
    }
}
