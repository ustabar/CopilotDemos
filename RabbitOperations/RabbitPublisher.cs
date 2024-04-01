using RabbitMQ.Client;
using System.Text;

class Publisher
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel=connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "my_exchange", type: ExchangeType.Fanout);

            var message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "my_exchange",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            console.WriteLine(" [x] Sent {0}", message);
        }
    }
}