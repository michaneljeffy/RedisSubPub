using System;
using StackExchange.Redis;

namespace RedisSub
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
            {
                ISubscriber sub = redis.GetSubscriber();//获取订阅器
                sub.Subscribe("messages", (channel, message) =>
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
                });
            }
            Console.WriteLine("subscrible message success");
            Console.ReadKey();
               
        }
    }
}
