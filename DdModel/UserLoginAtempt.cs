using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTech.DbModel
{
    public class UserLoginAtempt
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string AttemptTime { get; set; }
        [Required]
        public bool IsSuccess { get; set; }
    }
}