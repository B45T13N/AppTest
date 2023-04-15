using System.Collections.Generic;
using System.Threading.Tasks;
using CLAppTestSupabase.Business.Interfaces;
using CLAppTestSupabase.Business.Mappers;
using CLAppTestSupabase.Business.Models;
using CLAppTestSupabase.Data;
using Postgrest;
using Client = Supabase.Client;

namespace CLAppTestSupabase.Business.Services;

public class TodoService : ITodoService
{
    public Client SupabaseClient { get; set; }
    
    public TodoService(string url, string key)
    {
         SupabaseClient = SupabaseConnexion.GetConnexion(url, key);
    }
    
    public async Task<IEnumerable<Todo>> GetTodos()
    {
        var todos = await SupabaseClient
            .From<Data.Models.Todo>()
            .Get();

        return todos.Models.ToModel();
    }

    public async Task<Todo> GetTodo(int id)
    {
        var todo = await SupabaseClient
            .From<Data.Models.Todo>()
            .Filter("id", Constants.Operator.Equals, id)
            .Get();

        return todo.Models[0].ToModel();
    }

    public async Task<Todo> InsertTodo(Todo todo)
    {
        var newTodo = await SupabaseClient
            .From<Data.Models.Todo>()
            .Insert(todo.ToEntity());

        return newTodo.Models[0].ToModel();
    }
}