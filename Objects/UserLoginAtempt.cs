using System;

namespace TaskTech.Object
{
    public class UserLoginAtempt
    {
        public UserLoginAtempt(Guid id, string attemptTime, bool isSuccess)
        {
            Id = id;
            AttemptTime = attemptTime;
            IsSuccess = isSuccess;
        }

        public Guid Id { get; set; }

        public string AttemptTime { get; set; }

        public Boolean IsSuccess { get; set; }
    }
}