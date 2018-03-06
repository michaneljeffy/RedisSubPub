using System;
using StackExchange.Redis;

namespace RedisPub
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
            {
                ISubscriber sub = redis.GetSubscriber();
                Console.WriteLine("请输入任意字符，输入exit退出");
                string input;
                do
                {
                    input = Console.ReadLine();
                    sub.Publish("messages", input);
                } while (input != "exit");
            }
        }
    }
}
