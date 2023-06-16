namespace ParkBee.Asssessment.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public User(string password, string name)
        {
            Password = password;
            Name = name;
        }
        
        public UserId Id { get; private set; }

        public string Name { get; }

        public string Password { get; }
        
        public string Email { get; set; }

        public int GarageId { get; set; }
    }
}