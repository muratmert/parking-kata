using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using ParkBee.Assessment.Application.Garages;
using ParkBee.Assessment.Domain.Garages;
using Xunit;

namespace ParkBee.Asessment.Application.UnitTest.Garages
{
    public class GetGarageByIdQueryHandlerTest
    {
        [Fact]
        public async Task When_GetGarageByIdQuery_Requested_Then_GarageDto_Should_Return_Successfully()
        {
            //arrange
            IGarageRepository garageRepository = A.Fake<IGarageRepository>();
            GetGarageByIdQueryHandler queryHandler = new GetGarageByIdQueryHandler(garageRepository);
            GetGarageByIdQuery query = new GetGarageByIdQuery(5);
            Garage garage = new Garage("garage1", "address");
            garage.AddDoor(new Door("ipaddress1",true));
            garage.AddDoor(new Door("ipaddress2",false));

            A.CallTo(() => garageRepository.GetGarageById(query.GarageId)).Returns(garage);
            //act
            List<GarageDto> garages = await queryHandler.Handle(query, default);

            //assert
            garages.Should().NotBeNull().And.HaveCount(2);
            garages[0].Name.Should().Be(garage.Name);
            garages[0].IpAddress.Should().Be("ipaddress1");
            garages[0].Status.Should().Be(true);
            A.CallTo(() => garageRepository.GetGarageById(query.GarageId)).MustHaveHappened();
        }
    }
}