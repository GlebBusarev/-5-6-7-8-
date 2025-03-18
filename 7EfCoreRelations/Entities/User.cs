using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string LastName  { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string Login { get; set; }
        public string Password {  get; set; }

        public List<Role> Roles { get; set; }
        public List<Note> Notes { get; set; }

        public User() { }

        public User(int id, string lastName, string firstName, string? middleName, string login, string password)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Login = login;
            Password = password;
        }
    }

}