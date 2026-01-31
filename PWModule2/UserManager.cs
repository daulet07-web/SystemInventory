using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PWModule2
{
    internal class UserManager
    {
        private List<User> users = new List<User>();
        public void AddUser(string name, string email, string role)
        {
            users.Add(new User 
            { 
            Name = name,
            Email = email,
            Role = role 
            });
            Console.WriteLine($"Пользователь {name} с ролью {role} был успешно добавлен");
        }
        public void RemoveUser(string email)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"Пользователь {email} был удалён");
            }
            else
            {
                Console.WriteLine($"Пользователь с email {email} не найден");
            }
        }
        public void UpdateUser(string name, string email, string role)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                user.Name = name;
                user.Role = role;
                Console.WriteLine($"Пользователь {email} был изменён на {name} с ролью {role}");
            }
            else
            {
                Console.WriteLine($"Пользователь с email {email} не найден");
            }
        }
    }
}
