using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class ServiceHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ServiceHistoryID { get; set; }
        public DateTime ServiceDoneDate { get; set; } 
        public string ServiceNotes {get; set;}
        public DateTime InsertDateTime { get; set; }
        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }
        public string AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetDetails AssetDetails { get; set; }
        public string ServiceDetailID { get; set; }
        [ForeignKey("ServiceDetailID")]
        public ServiceDetails ServiceDetails { get; set; }
    }
}
