using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class AssetRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string AssetRequestID { get; set; }

        public string Asset_Name { get; set; }
        public string Asset_Purpose { get; set; }
        public string Asset_cost { get; set; }
        public DateTime RequestDate { get; set; }
        public string Requeststatus { get; set; }
        public string Procurestatus { get; set; }
        public string Procure_approval { get; set; }
        public string Ast_added { get; set; }

        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime InsertDateTime { get; set; }

    }
}
