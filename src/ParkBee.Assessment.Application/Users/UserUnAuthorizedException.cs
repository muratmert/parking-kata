using System;

namespace ParkBee.Assessment.Application.Users
{
    public class UserUnAuthorizedException : Exception
    {
        public UserUnAuthorizedException(string message) : base(message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}