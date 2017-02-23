using System;
using System.Collections.Generic;
using System.Linq;
using R5AppData.DataContract;
using R5AppData.ResourceAccess.UnitOfWork;
using R5AppData.ServiceContract;

namespace R5AppData.ServiceImplementation
{
    public class R5AppDataService : IR5AppDataService
    {
        private readonly IUnitOfWork unitOfWork;

        public R5AppDataService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<R5AppFacilityInfo> GetFacilities()
        {
            var fac = from f in unitOfWork.R5FacilityRepository.Get()
                select new R5AppFacilityInfo()
                {
                    FacilityGuid = f.Facility_Guid,
                    FacilityName = f.Location_Name
                };
            return fac;
        }

        public IEnumerable<R5AppBedInfo> GetBeds(Guid facilityGuid)
        {
            var bed = from b in unitOfWork.R5BedRepository.Get(x => x.Facility_Guid == facilityGuid)
                select new R5AppBedInfo()
                {
                    FacilityName = b.Facility_Name,
                    AreaName = b.Area_Name,
                    RoomName = b.Room_Name,
                    BedName = b.Bed_Name,
                    LocationId = b.Bed_Id
                };
            return bed;
        }
    }
}
