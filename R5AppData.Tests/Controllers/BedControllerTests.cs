using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using R5AppData.DataContract;
using R5AppDataWebService.Controllers;
using Xunit;

namespace R5AppData.Tests.Controllers
{
    [Collection("service collection")]
    public class BedControllerTests
    {
        private readonly ServiceFixture fixture;

        public BedControllerTests(ServiceFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact()]
        public void GetTest()
        {
            var controller = new BedController(fixture.Service);
            var result = controller.Get(Guid.NewGuid());
            var contentResult = result as OkNegotiatedContentResult<IEnumerable<R5AppBedInfo>>;

            Assert.NotNull(contentResult);
            Assert.Equal(2, contentResult.Content.Count());
        }
    }
}