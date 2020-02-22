using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.parking
{
    public class ParkingAssignmentHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ParkingAssignmentHistoryID { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime Currdate { get; set; }
        public string Parking_ID { get; set; }
        public string Owner_fname { get; set; }
        public string Owner_lname { get; set; }
        public string Owner_flatno { get; set; }
        public string Owner_phno { get; set; }
        public string Owner_email { get; set; }
        public string Owner_slotno { get; set; }
    }
}
