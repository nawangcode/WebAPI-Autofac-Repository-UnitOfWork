using System;
using R5AppData.ResourceAccess.Repository;

namespace R5AppData.ResourceAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<vwLocation_Bed_FQN> R5BedRepository { get; }
        IGenericRepository<vwLocation_Site> R5FacilityRepository { get; }
        bool Save();
    }
}
