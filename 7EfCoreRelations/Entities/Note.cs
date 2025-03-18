using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; }

        public Note() { }

        public Note(
            int id,
            string title,
            string? description,
            DateTime createdAt,
            DateTime? updatedAt
            )
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}