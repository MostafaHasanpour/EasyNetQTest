using EasyNetQ;
using Message;
using System;
using System.Threading;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                int i = 0;
                while ((input = (i++).ToString()/*Console.ReadLine()*/) != "Quit")
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                    Console.WriteLine(input);
                    Thread.Sleep(2000);
                }
            }
        }
    }
    ///Start RabitMQ (https://cmatskas.com/getting-started-with-rabbitmq-on-windows/)
    ///Github EasyNetQ (https://github.com/EasyNetQ/)
}
