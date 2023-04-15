using System.Collections.Generic;
using System.Linq;
using CLAppTestSupabase.Business.Models;

namespace CLAppTestSupabase.Business.Mappers;

public static class TodoMapper
{
    public static Todo ToModel(this Data.Models.Todo entity)
    {
        var todo = new Todo
        {
            Id = entity.Id,
            Note = entity.Note,
            Title = entity.Title,
            CreationDate = entity.CreationDate
        };

        return todo;
    }
    
    public static Data.Models.Todo ToEntity(this Todo todo)
    {
        var entity = new Data.Models.Todo
        {
            Note = todo.Note,
            Title = todo.Title,
            CreationDate = todo.CreationDate
        };

        return entity;
    }
    
    public static IEnumerable<Data.Models.Todo> ToEntity(this IEnumerable<Todo> todos)
    {
        return todos.Select(todo => todo.ToEntity()).ToList();
    }
    
    public static IEnumerable<Todo> ToModel(this IEnumerable<Data.Models.Todo> todos)
    {
        return todos.Select(todo => todo.ToModel()).ToList();
    }
}