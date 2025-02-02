using backend.Kafka;
using backend.Models;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MicroServiceController : ControllerBase
    {
        private readonly ProducerConfig producerConfig;

        [HttpPost]
        [Route("TestKafka")]
        public ActionResult TestKafka(string topic , string message)
        {
            new KafkaProducer(producerConfig).SendMessageAsync(topic, message);
            return Ok("Kafka Done!");    
        }
    }
}
