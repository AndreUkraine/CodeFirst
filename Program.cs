using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstApp
{
    class Program
    {

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tommi", Age = 93 };
                User user2 = new User { Name = "Sammi", Age = 86 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                }
                Console.Read();
            }

            //using (UserContext db = new UserContext())
            //{
            //    var users = db.Users;
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
            //    }
            //}

            Console.ReadKey();
        }
    }

      


}
