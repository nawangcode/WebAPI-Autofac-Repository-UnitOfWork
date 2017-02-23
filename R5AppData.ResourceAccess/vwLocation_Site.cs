using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R5AppData.ResourceAccess
{
    public partial class vwLocation_Site
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Location_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Location_Name { get; set; }

        [StringLength(255)]
        public string Location_Description { get; set; }

        public Guid Facility_Guid { get; set; }
    }
}
