using System;
using Confluent.Kafka;

namespace KafkaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers",
                BootstrapServers = "localhost:9092"
            };

            using (var consumer=new ConsumerBuilder<Null,string>(config).Build())
            {
                consumer.Subscribe("temp-topic");
                while(true)
                {
                    var cr = consumer.Consume();
                    Console.WriteLine(cr.Message.Value);
                }
            }
        }
    }
}
