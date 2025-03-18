using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public List<Role> Roles { get; set; }

        public Permission() { }

        public Permission(int id, string title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}