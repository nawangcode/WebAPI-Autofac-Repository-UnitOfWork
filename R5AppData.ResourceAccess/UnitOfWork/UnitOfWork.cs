using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using R5AppData.ResourceAccess.Repository;

namespace R5AppData.ResourceAccess.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private static readonly TraceSource TraceSource = new TraceSource("R5AppDataTraceSource", SourceLevels.Error);

        private readonly R5AppContext context;

        private GenericRepository<vwLocation_Site> r5FacilityRepository;
        private GenericRepository<vwLocation_Bed_FQN> r5BedRepository;

        public UnitOfWork(R5AppContext context)
        {
            this.context = context;
        }

        public IGenericRepository<vwLocation_Bed_FQN> R5BedRepository => r5BedRepository ?? (r5BedRepository = new GenericRepository<vwLocation_Bed_FQN>(context));

        public IGenericRepository<vwLocation_Site> R5FacilityRepository => r5FacilityRepository ?? (r5FacilityRepository = new GenericRepository<vwLocation_Site>(context));

        public bool Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                //SqlException s = e.InnerException.InnerException as SqlException;
                //Debug.WriteLine(s.Message);
                TraceSource.TraceData(TraceEventType.Error, 0, e);
                return false;
            }
            return true;
        }

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }


    }
}
