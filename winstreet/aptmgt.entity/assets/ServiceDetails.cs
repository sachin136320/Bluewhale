using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class ServiceDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ServiceDetailID { get; set; } 
        
        public bool RequireServiceFlag { get; set; }   
        public string ServiceFrequencyinDays { get; set; } // in terms of days
        public DateTime NextServiceDate { get; set; }
        public DateTime LastServiceDoneDate { get; set; } 
        public string LastServiceNotes {get; set;}

        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }
        
        public string AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetDetails AssetDetails { get; set; }
    }
}