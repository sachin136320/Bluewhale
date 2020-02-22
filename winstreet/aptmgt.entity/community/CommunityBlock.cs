using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.community
{
    public class CommunityBlock
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string BlockID { get; set; }
        public string Blckname { get; set; }
        public int NumberofFloors { get; set; }
        public int NumberofFlats { get; set; }

        public ICollection<CommunityFlats> Flats { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }
    }
}
