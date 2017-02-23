using System;
using System.Web.Http;
using R5AppData.ServiceContract;

namespace R5AppDataWebService.Controllers
{
    public class BedController : ApiController
    {
        private readonly IR5AppDataService service;

        public BedController(IR5AppDataService service)
        {
            this.service = service;
        }

        [Route("api/bed/{facilityGuid}")]
        public IHttpActionResult Get(Guid facilityGuid)
        {
            var bed = service.GetBeds(facilityGuid);
            if (bed == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(bed); // Returns an OkNegotiatedContentResult 
        }
    }
}
