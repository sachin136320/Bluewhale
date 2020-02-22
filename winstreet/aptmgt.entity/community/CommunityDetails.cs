using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aptmgt.entity.facility;

namespace aptmgt.entity.community
{
    public class CommunityDetails
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string CommunityId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        
        public string BuilderID { get; set; }
        [ForeignKey("BuilderID")]
        public builder.Builder Builder { get; set; }

        public ICollection<CommunityBlock> Blocks { get; set; }

        public ICollection<FacilityMaster> Facility { get; set; }
        
        
    }
}
