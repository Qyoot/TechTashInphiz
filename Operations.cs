using System;
using System.Collections.Generic;
using System.Text.Json;
using TaskTech.DbContextFolder;
using TaskTech.Object;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TaskTech
{
    public class Operations
    {
        
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

            _db.AddRange(UserGenertor());
            _db.SaveChanges();
        }

        public string GetByEmail(string email)
        {
            var users = _db.Users.Where(p => p.Email == email).Include(e => e.LoginAtempts).ToList();
            //TODO: MAke Json generator for users
            return null;
        }

        public string Statistic(DateTime startDate, DateTime endDate,int metric,bool isSuccess)
        {
            //TODO: Make Statistic querry
            return null;
        }

        public List<T>[] Partition<T>(List<T> list, int totalPartitions)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (totalPartitions < 1)
                throw new ArgumentOutOfRangeException("totalPartitions");

            List<T>[] partitions = new List<T>[totalPartitions];

            int maxSize = (int)Math.Ceiling(list.Count / (double)totalPartitions);
            int k = 0;

            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = new List<T>();
                for (int j = k; j < k + maxSize; j++)
                {
                    if (j >= list.Count)
                        break;
                    partitions[i].Add(list[j]);
                }
                k += maxSize;
            }
            return partitions;
        }

        private List<User> UserGenertor(){
            List<User> users = new List<User>();
            for(int i = 0; i > 10; ++i)
            {
                var id = Guid.NewGuid();
                Person person = GetPerson();
                users.Add(new User(id,person.Email,person.Name,person.Surname, GetLoginAttempts(id,i)));
            }
            return users;
        }

        private Person GetPerson()
        {
            Random random = new Random();
            string file = File.ReadAllText("DataForGenerator\\PersonV2.json");

            var people = JsonSerializer.Deserialize<List<Person>>(file);

            return people[random.Next(0, 59)];
        }

        private List<UserLoginAtempt> GetLoginAttempts(Guid id,int index)
        {
            string file = File.ReadAllText("DataForGenerator\\LoginAttempts.json");
           
            var allAtempts = JsonSerializer.Deserialize<List<UserLoginAtempt>>(file);

            var parts = Partition<UserLoginAtempt>(allAtempts, 10);
            List<UserLoginAtempt> atempts = null;
            atempts.AddRange(parts[index]);
            foreach (var item in atempts)
            {
                item.Id = id;
            }

            return atempts;
        }    
    }
}
