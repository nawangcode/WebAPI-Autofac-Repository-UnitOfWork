using System.Data.Entity;

namespace R5AppData.ResourceAccess
{
    public partial class R5AppContext : DbContext
    {
        public R5AppContext()
            : base("name=R5AppContext")
        {
        }

        public R5AppContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<vwLocation_Bed_FQN> vwLocation_Bed_FQN { get; set; }
        public virtual DbSet<vwLocation_Site> vwLocation_Site { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
