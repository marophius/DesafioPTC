using Desafio.Domain.Entidades;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace Desafio.Qeue.Consumer
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {
                HostName = "localhost" , 
                //Port = 15672,
                //UserName = "guest",
                //Password = "guest",
                //Ssl =
                //{
                //    ServerName = "localhost" ,
                //    Enabled = true 
                //}
            };

            using (var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "veiculoQeue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var veiculo = JsonSerializer.Deserialize<Veiculo>(message);
                    Console.WriteLine($"[x] Received {veiculo.Modelo} - {veiculo.AnoFabricacao} - {veiculo.AnoModelo}");
                    
                   
                };

                channel.BasicConsume(queue: "veiculoQeue", autoAck: false, consumer: consumer);
                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}