using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CLAppTestSupabase.Business.Models;

namespace CLAppTestSupabase.Business.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetTodos();
    Task<Todo> GetTodo(int id);
    Task<Todo> InsertTodo(Todo todo);
}