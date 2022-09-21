using StackExchange.Redis;
using System;

namespace Publisher
{
    internal class Publisher
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel"; // Pub/Sub Channel
        static void Main(string[] args)
        {
            var pub = connection.GetSubscriber();

            pub.PublishAsync(Channel, "This is a test message!!", CommandFlags.FireAndForget);
            Console.Write("Message Successfully sent to test-channel");

            Console.ReadLine();
        }
    }
}
