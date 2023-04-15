using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace CLAppTestSupabase.Data.Models
{
    [Table("todos")]
    public class Todo : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("created_at")]
        public DateTime CreationDate { get; set; }
    }
}