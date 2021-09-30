
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTech.Object
{
    public class User : IPerson
    {
        public User(Guid id, string email, string name, string surname, List<UserLoginAtempt> loginAtempts)
        {
            Id = id;
            Email = email;
            Name = name;
            Surname = surname;
            LoginAtempts = loginAtempts;
        }

        public Guid Id { get; set; }
        public string Email {
            get { return Email; }
            set {
                if(new EmailAddressAttribute().IsValid(value))
                {
                    if(value is null)
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        Email = value;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
                
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<UserLoginAtempt> LoginAtempts { get; set; }
    }
}
