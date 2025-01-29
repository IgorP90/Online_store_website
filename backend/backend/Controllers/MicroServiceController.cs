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
        //private readonly ProducerConfig producer;

        [HttpPost]
        [Route("TestKafka")]
        public void TestKafka(string topic , string message)
        {
            new KafkaProducer().SendMessageAsync(topic, message);
            System.Diagnostics.Debug.WriteLine("ЁЁЁЁЁЁЁЁЁЁЁЁ!!!");
        }

        /*[HttpPost]
        [Route("TestKafka")]
        public void TestKafka(string message)
        {
            string topic = "order-events";

            Message<string, string> km = new Message<string, string>
            {
                Value = message
            };

            producer.Produce(topic, km);
        }*/

    }
}
