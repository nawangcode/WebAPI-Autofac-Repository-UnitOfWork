using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moq;
using R5AppData.ResourceAccess;
using R5AppData.ResourceAccess.Repository;
using R5AppData.ResourceAccess.UnitOfWork;

namespace R5AppData.Tests.Service
{
    public class DataBaseFixture : IDisposable
    {
        public IUnitOfWork UnitOfWork { get; }

        public Guid KnownFacilityGuid { get; } = Guid.Parse("C7F103F2-3155-454C-B91E-6766A3674EFE");
        private static readonly Guid facilityGuid2 = Guid.Parse("20847A4A-137C-4128-A0B3-7194933F68FD");

        

        public DataBaseFixture()
        {
            vwLocation_Site[] facilityList = {
                new vwLocation_Site
                {
                    Location_Id = 1,
                    Location_Name = "TestFacility1",
                    Location_Description = "Test",
                    Facility_Guid = KnownFacilityGuid
                },
                new vwLocation_Site
                {
                    Location_Id = 2,
                    Location_Name = "TestFacility2",
                    Location_Description = "Test",
                    Facility_Guid = facilityGuid2
                }
            };

        vwLocation_Bed_FQN[] bedList = {
                new vwLocation_Bed_FQN()
                {
                    Facility_Id = 1,
                    Facility_Guid = KnownFacilityGuid,
                    Facility_Name = "TestFacility1",
                    Area_Id = 2,
                    Area_Name = "TestArea1",
                    Room_Id = 3,
                    Room_Name = "TestRoom1",
                    Bed_Id = 4,
                    Bed_Name = "TestBed1",
                    Bed_FQN = "1234"
                },
                new vwLocation_Bed_FQN()
                {
                    Facility_Id = 1,
                    Facility_Guid = KnownFacilityGuid,
                    Facility_Name = "TestFacility1",
                    Area_Id = 2,
                    Area_Name = "TestArea1",
                    Room_Id = 3,
                    Room_Name = "TestRoom1",
                    Bed_Id = 5,
                    Bed_Name = "TestBed2",
                    Bed_FQN = "1234"
                },
                new vwLocation_Bed_FQN()
                {
                    Facility_Id = 2,
                    Facility_Guid = facilityGuid2,
                    Facility_Name = "TestFacility2",
                    Area_Id = 12,
                    Area_Name = "TestArea1",
                    Room_Id = 13,
                    Room_Name = "TestRoom1",
                    Bed_Id = 15,
                    Bed_Name = "TestBed2",
                    Bed_FQN = "1234"
                }
            };

        var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockFacilityRepository = new Mock<IGenericRepository<vwLocation_Site>>();
            var mockBedRepository = new Mock<IGenericRepository<vwLocation_Bed_FQN>>();

            mockFacilityRepository.Setup(SetupGenericGet<vwLocation_Site>())
                .Returns(facilityList);
            mockBedRepository.Setup(SetupGenericGet<vwLocation_Bed_FQN>())
                .Returns(bedList.Where(b => b.Facility_Guid.Equals(KnownFacilityGuid)));

            mockUnitOfWork.SetupGet(x => x.R5FacilityRepository)
                .Returns(mockFacilityRepository.Object);
            mockUnitOfWork.SetupGet(x => x.R5BedRepository)
                .Returns(mockBedRepository.Object);

            UnitOfWork = mockUnitOfWork.Object;
        }

        private static Expression<Func<IGenericRepository<T>, IEnumerable<T>>> SetupGenericGet<T>()
        {
            return x => x.Get(It.IsAny<Expression<Func<T, bool>>>(), It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(), It.IsAny<string>());
        }
        public void Dispose()
        {
        }
    }
}
