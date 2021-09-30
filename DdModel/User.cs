using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTech.DbModel
{
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Email { get; set; }
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string Surname { get; set; }
        [Required]
        public List<UserLoginAtempt> LoginAtempts { get; set; }
    }
}
