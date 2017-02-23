using System.Linq;
using R5AppData.ServiceImplementation;
using Xunit;

namespace R5AppData.Tests.Service
{
    public class R5AppDataServiceTests : IClassFixture<DataBaseFixture>
    {
        private readonly DataBaseFixture fixture;

        public R5AppDataServiceTests(DataBaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact()]
        public void GetFacilitiesTest()
        {
            var r5AppDataService = new R5AppDataService(fixture.UnitOfWork);
            var result = r5AppDataService.GetFacilities();

            Assert.Equal(2, result.Count());
        }

        [Fact()]
        public void GetBedsTest()
        {
            var r5AppDataService = new R5AppDataService(fixture.UnitOfWork);

            var result = r5AppDataService.GetBeds(fixture.KnownFacilityGuid);

            Assert.Equal(2, result.Count());
        }
    }
}