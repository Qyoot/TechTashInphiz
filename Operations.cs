using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.SqlServer;
using TaskTech.DbContextFolder;
using TaskTech.Object;
using System.Linq;

namespace TaskTech
{
    public class Operations
    {
        Random random = new Random();
        private readonly DataContext _db;
        public void Init()
        {
            if(_db.Users.Count() != 0)
            {
                var users = _db.Users;
                _db.RemoveRange(users);
                var attempts = _db.UserLoginAtempts;
                _db.RemoveRange(attempts);
                _db.SaveChanges();
            }
            

            
        }
        public string GetByEmail(string email)
        {
            return null;
        }
        public string Statistic(DateTime startDate, DateTime endDate,int metric,bool isSuccess)
        {

            return null;
        }

        private List<User> UserGenertor(){
            List<User> users = new List<User>();
            for(int i = 0; i > 10; ++i)
            {
                var id = Guid.NewGuid();
                Person person = GetPerson();
                users.Add(new User(id,person.Email,person.Name,person.Surname,/*login attempts*/ null));
            }
            return users;
        }
        private Guid GetGuid()
        {
            string file = System.IO.File.ReadAllText("DataForGenerator\\Guid.json");

            var guids = JsonSerializer.Deserialize<List<Guid>>(file);

            return guids[random.Next(0, 49)];

        }
        private Person GetPerson()
        {
            string file = System.IO.File.ReadAllText("DataForGenerator\\PersonV2.json");

            var people = JsonSerializer.Deserialize<List<Person>>(file);

            return people[random.Next(0, 60)];
        }

        private List<UserLoginAtempt> GetLoginAttempts()
        {
            string file = System.IO.File.ReadAllText("DataForGenerator\\LogginAttempts.json");

            var attempts = JsonSerializer.Deserialize<List<UserLoginAtempt>>(file);

            return new List<UserLoginAtempt>();
        }
    }
}
