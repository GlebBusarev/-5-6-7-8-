using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShopBusarev.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public UserEntity()
        {

        }


        public UserEntity(
            string name,
            string secondname,
            string login,
            string password)
        {
            Login = login;
            Password = password;
            Name = name;
            SecondName = secondname;
        }

    }
}
