using System;

namespace ParkBee.Assessment.Application.Garages
{
    public class GarageNotFoundException : Exception
    {
        public GarageNotFoundException(string message):base(message)
        {
            Message = message;
        }
        
        public override string Message { get; }
    }
}