using System;

namespace CLAppTestSupabase.Business.Models;

public class Todo
{
    public int Id { get; set; }
    public string Note { get; set; }
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
}