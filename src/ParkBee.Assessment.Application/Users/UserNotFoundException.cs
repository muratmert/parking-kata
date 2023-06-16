using System;

namespace ParkBee.Assessment.Application.Users
{
    public class UserNotFoundException : Exception
    {
        
        public UserNotFoundException(string message) : base(message)
        {
            Message = message;
        }
        
        public override string Message { get;  }
    }
}