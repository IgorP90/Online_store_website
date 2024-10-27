using backend.Models;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MicroServiceController : ControllerBase
    {
        private readonly IProducer<string, string> producer;
        public MicroServiceController(IProducer<string, string> producer) => this.producer = producer;

        [HttpPost]
        [Route("TestKafka")]
        public void TestKafka(string message)
        {
            string topic = "order-events";

            Message<string, string> km = new Message<string, string>
            {
                Value = message
            };

            producer.Produce(topic, km);
        }
    }
}
