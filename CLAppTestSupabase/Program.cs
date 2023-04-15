using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CLAppTestSupabase.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supabase;

namespace CLAppTestSupabase
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Setup Host
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            
            Console.WriteLine("Welcome to the Supabase CL Test");
            Console.WriteLine("This project is made to test Supabase Fonctionnality");
            
            Console.WriteLine($"{Environment.NewLine} To read todos registered, please press 1,");
            Console.WriteLine("To register a new todo, please press 2");

            var keyPressed = Console.ReadLine();

            Console.WriteLine(keyPressed);
        }

    }
}