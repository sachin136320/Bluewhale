using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.community
{
    public class CommunityFlats
    {
        private string _flatID;
        private string _flatNumber;
        private int _floorNumber;
        private int _ownerID;


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string FlatID { get => _flatID; set => _flatID = "FlatID_" + value; }
        public string FlatNumber { get => _flatNumber; set => _flatNumber = value; }
        public int FloorNumber { get => _floorNumber; set => _floorNumber = value; }
        public int OwnerID { get => _ownerID; set => _ownerID = value; }


        public user.OwnerMaster owner { get; set; }

        public string BlockID { get; set; }
        [ForeignKey("BlockID")]
        public community.CommunityBlock Block { get; set; }
    }
}
