
namespace ParkBee.Assessment.Application.Garages
{
    public class GarageDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int DoorId { get; set; }
        
        public bool Status { get; set; }

        public string IpAddress { get; set; }
    }
}