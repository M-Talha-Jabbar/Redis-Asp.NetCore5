using StackExchange.Redis;
using System;

namespace Subscriber
{
    internal class Subscriber
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel"; // Pub/Sub Channel
        private const string KeyspaceChannel = "__keyspace*__:mykey"; // Keyspace notifications
        static void Main(string[] args)
        {
            Console.WriteLine("Listening test-channel");
            var sub = connection.GetSubscriber();

            sub.Subscribe(Channel, (channel, message) => Console.Write("Message received from test-channel : " + message + "\n"));

            sub.Subscribe(KeyspaceChannel, (channel, value) => Console.Write("Following command is executed on mykey : " + value + "\n"));

            Console.ReadLine();
        }
    }
}
