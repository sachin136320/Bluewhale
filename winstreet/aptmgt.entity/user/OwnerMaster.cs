using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{
//MemberShipTypes is missing in next revision add it
    public class OwnerMaster 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ResidentID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FlatNumber { get; set; }
        public bool Occupied { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public byte[] Picture;
        public string QRText { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }

        public string OwnerType { get; set; }

        //applicable for tenants
        public bool AgreementCopySubmitted { get; set; }
 
        public DateTime InsertDateTime { get; set; }

        public string FlatID { get; set; }
        [ForeignKey("FlatID")]
        public community.CommunityFlats CommunityFlats { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

    }
}