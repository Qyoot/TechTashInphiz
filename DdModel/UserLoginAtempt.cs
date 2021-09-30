using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTech.DbModel
{
    public class UserLoginAtempt
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TimeSpan AttemptTime { get; set; }
        [Required]
        public Boolean IsSuccess { get; set; }
    }
}