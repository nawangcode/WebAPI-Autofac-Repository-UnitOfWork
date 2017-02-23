using System;
using System.Collections.Generic;
using Moq;
using R5AppData.DataContract;
using R5AppData.ServiceContract;

namespace R5AppData.Tests.Controllers
{
    public class ServiceFixture:IDisposable
    {
        public IR5AppDataService Service { get; }

        private readonly List<R5AppFacilityInfo> facilities = new List<R5AppFacilityInfo>()
        {
            new R5AppFacilityInfo()
            {
                FacilityGuid = Guid.NewGuid(),
                FacilityName = "TestFacility"
            },
            new R5AppFacilityInfo()
            {
                FacilityGuid = Guid.NewGuid(),
                FacilityName = "TestFacility2"
            }
        };

        private  readonly List<R5AppBedInfo> beds=new List<R5AppBedInfo>()
        {
            new R5AppBedInfo()
            {
                FacilityName = "TestFacility",
                AreaName = "TestArea",
                RoomName = "TestRoom",
                BedName = "TestBed",
                LocationId = 1
            },
            new R5AppBedInfo()
            {
                FacilityName = "TestFacility",
                AreaName = "TestArea",
                RoomName = "TestRoom",
                BedName = "TestBed2",
                LocationId = 2
            }
        };


        public ServiceFixture()
        {
            var mockService = new Mock<IR5AppDataService>();
            mockService.Setup(x => x.GetFacilities()).Returns(facilities);
            mockService.Setup(x => x.GetBeds(It.IsAny<Guid>())).Returns(beds);
            Service = mockService.Object;
        }
        public void Dispose()
        {
        }

    }
}