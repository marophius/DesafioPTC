using Desafio.Domain.Entidades;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Desafio.Qeue.Consumer
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){
               HostName = "bunny",
               Port = 5672
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
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var veiculo = JsonSerializer.Deserialize<Veiculo>(message);

                        Console.WriteLine($"[x] Received {veiculo.Modelo} - {veiculo.AnoFabricacao} - {veiculo.AnoModelo}");

                        channel.BasicAck(ea.DeliveryTag, false);

                        var smtp = new SmtpClient
                        {
                            EnableSsl = true,

                        };

                        if (veiculo.Proprietario.Email.Contains("@gmail.com"))
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;

                        }
                    }
                    catch (Exception ex) {

                        channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                    
                   
                };

                channel.BasicConsume(queue: "veiculoQeue", autoAck: false, consumer: consumer);
                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}