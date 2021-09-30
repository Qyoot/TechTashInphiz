using System;
using System.Collections.Generic;
using System.Text.Json;

using TaskTech.DbContextFolder;
using TaskTech.Object;

namespace TaskTech
{
    public class Operations
    {
        Random random = new Random();
        private readonly DataContext _db;
        public void Init()
        {
            var users = _db.Users;
            _db.RemoveRange(users);
            var attempts = _db.UserLoginAtempts;
            _db.RemoveRange(attempts);

            _db.AddRange(users);
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
                Person person = TakePerson();
                users.Add(new User(Guid.NewGuid(),person.Email,person.Name,person.Surname,/*login attempts*/null));
            }
            return users;
        }
        private Person TakePerson()
        {
            string file = System.IO.File.ReadAllText("DataForGenerator\\PersonV2.json");

            var people = JsonSerializer.Deserialize<List<Person>>(file);
            Person person = people[random.Next(0, 60)];

            return person;
        }
    }
}
