using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Workshop2019.EmployeeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Goooood");
        
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
            
            Console.WriteLine("Finished");
        }
    }
}
