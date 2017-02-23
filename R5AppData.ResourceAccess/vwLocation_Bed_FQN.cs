using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R5AppData.ResourceAccess
{
    public class vwLocation_Bed_FQN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Facility_Id { get; set; }

        public Guid Facility_Guid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Facility_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Area_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Area_Name { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_Id { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Room_Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bed_Id { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Bed_Name { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(214)]
        public string Bed_FQN { get; set; }

        public DateTime? Activate_Date { get; set; }

        public DateTime? Inactivate_Date { get; set; }
    }
}
