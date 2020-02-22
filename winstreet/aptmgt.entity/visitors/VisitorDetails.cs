using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class VisitorDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string VisitID { get; set; }
        
        public string Name { get; set; }
        public string NumberOfVisitor { get; set; }
        public string CheckInDate { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }
        
        public string Address { get; set; } 
        public string MobileNumber { get; set; }
        public string VisitorType { get; set; }
        public byte[] Picture { get; set; } 
        public string ResidentID { get; set; }

    }
}