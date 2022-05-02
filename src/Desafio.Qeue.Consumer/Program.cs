using Desafio.Data.Repositories;
using Desafio.Domain.Entidades;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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

                        SendEmail(veiculo.Proprietario.Email, veiculo);

                        channel.BasicAck(ea.DeliveryTag, false);

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

        public static void SendEmail(string emailAddress, Veiculo veiculo)
        {

            MailMessage email = new MailMessage();
            var smtp = new SmtpClient
            {
                EnableSsl = true,

            };

            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("seu-email-aqui", "sua-senha-aqui");
            email.From = new MailAddress("ifelix03@hotmail.com");
            email.Body = "Seu veículo foi cadastrado com sucesso!";
            email.Subject = $"{veiculo.Modelo} - {veiculo.AnoModelo} [Cadastrado]";
            email.To.Add(emailAddress);

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtp.Send(email);
        }
    }
}