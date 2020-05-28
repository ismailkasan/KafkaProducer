using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Confluent.Kafka;


namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
           

            var config = new ProducerConfig () { BootstrapServers = "localhost:9092" };

            using (var producer = new Producer<string, string> (config)) {
                while (true) {
                    Console.Write ("Enter message: ");
                    var text = Console.ReadLine ();

                    Message<string, string> message = new Message<string, string> { Value = text }; 
                    DeliveryReport<string, string> result = producer.ProduceAsync ("ToDoList", message).GetAwaiter().GetResult();    
                    Console.WriteLine ($"Delivered to '{result.TopicPartitionOffset}'");
                }
            }
        }
    }
}
