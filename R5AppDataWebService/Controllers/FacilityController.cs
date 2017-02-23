using System.Collections.Generic;
using System.Web.Http;
using R5AppData.DataContract;
using R5AppData.ServiceContract;

namespace R5AppDataWebService.Controllers
{
    public class FacilityController : ApiController
    {
        private readonly IR5AppDataService service;

        public FacilityController(IR5AppDataService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            IEnumerable<R5AppFacilityInfo> fac = service.GetFacilities();
            if (fac == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(fac);  // Returns an OkNegotiatedContentResult
        }
    }
}
