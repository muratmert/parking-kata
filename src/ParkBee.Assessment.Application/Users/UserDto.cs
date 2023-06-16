using System;

namespace ParkBee.Assessment.API.Controllers
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public int GarageId { get; set; }
    }
}