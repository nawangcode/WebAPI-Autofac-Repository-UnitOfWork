using System;
using System.Collections.Generic;
using R5AppData.DataContract;

namespace R5AppData.ServiceContract
{
    public interface IR5AppDataService
    {
        IEnumerable<R5AppFacilityInfo> GetFacilities();
        IEnumerable<R5AppBedInfo> GetBeds(Guid facilityGuid);
    }
}
