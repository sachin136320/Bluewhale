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

        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime InsertDateTime { get; set; }
        public string AssetId { get; set; }
        public string Asset_NR { get; set; }
        public string Asset_Name { get; set; }
        public string Asset_service_Freq { get; set; }
        public DateTime Asset_last_servce { get; set; }
        public string Asset_service_flag { get; set; }
        public DateTime Asset_service_date { get; set; }

    }
}
