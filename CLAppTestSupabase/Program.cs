using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CLAppTestSupabase.Business.Interfaces;
using CLAppTestSupabase.Business.Models;
using CLAppTestSupabase.Business.Services;
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

            ITodoService TodoService = new TodoService(config["SUPABASE:URL"], config["SUPABASE:KEY"]);
            
            Console.WriteLine("Welcome to the Supabase CL Test");
            Console.WriteLine("This project is made to test Supabase Fonctionnality");

            ShowInstructions();

            var keyPressed = Console.ReadLine();

            while (keyPressed != "0")
            {
                switch (keyPressed)
                {
                    case "1":
                        var todos = await TodoService.GetTodos();
                        ShowTodos(todos);
                        break;
                
                    case "2":
                        CreateANewTodo(TodoService);
                        break;
                }
                
                ShowInstructions();
                
                keyPressed = Console.ReadLine();
            }
        }

        private static void ShowInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{Environment.NewLine}To read todos registered, please press 1,");
            Console.WriteLine("To register a new todo, please press 2");
            Console.WriteLine("To stop, please press 0");
            
            Console.ResetColor();
        }

        private static async void CreateANewTodo(ITodoService todoService)
        {            
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Enter the todo's Title :");
            var title = Console.ReadLine();
            
            Console.WriteLine("Enter the todo's note :");
            var note = Console.ReadLine();
            
            var todo = new Todo
            {
                Title = title,
                Note = note
            };

            var newTodo = await todoService.InsertTodo(todo);
            
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"{Environment.NewLine}New todo added : {newTodo.Title}");
            Console.ResetColor();

        }

        private static void ShowTodos(IEnumerable<Todo> todos)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var todo in todos)
            {
                Console.WriteLine($"{Environment.NewLine}{todo.Title} : {todo.Note}");
            }
            
            Console.ResetColor();
        }

    }
}