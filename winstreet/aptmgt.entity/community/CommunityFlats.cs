using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.community
{
    public class CommunityFlats
    {
        private string _flatID; 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string FlatID { get => _flatID; set => _flatID = "FlatID_" + value; }
        
        public string FlatNumber { get; set; }
        public int FloorNumber { get; set; }

        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")] 
        public user.OwnerMaster owner { get; set; }

        public string BlockID { get; set; }
        [ForeignKey("BlockID")]
        public community.CommunityBlock Block { get; set; }
    }
}
