using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.vehicles

{
    public class VehicleDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string VehicleDetailsID { get; set; }
        
        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime InsertDateTime { get; set; } 
        public string Owner_fname { get; set; }
        public string Owner_lname { get; set; }
        public string Owner_flatno { get; set; }
        public string Owner_phno { get; set; }
        public string Owner_email { get; set; }
        public string Owner_slotno { get; set; }
        public string Vehicle_no { get; set; }
    }
}
