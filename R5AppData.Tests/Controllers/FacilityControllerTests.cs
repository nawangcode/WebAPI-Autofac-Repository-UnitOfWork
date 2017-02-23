using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using R5AppData.DataContract;
using R5AppDataWebService.Controllers;
using Xunit;

namespace R5AppData.Tests.Controllers
{
    [Collection("service collection")]
    public class FacilityControllerTests 
    {
        private readonly ServiceFixture fixture;

        public FacilityControllerTests(ServiceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact()]
        public void GetTest()
        {
            var controller = new FacilityController(fixture.Service);
            var result =controller.Get();
            var contentResult = result as OkNegotiatedContentResult<IEnumerable<R5AppFacilityInfo>>;

            Assert.NotNull(contentResult);
            Assert.Equal(2, contentResult.Content.Count());
        }
    }
}