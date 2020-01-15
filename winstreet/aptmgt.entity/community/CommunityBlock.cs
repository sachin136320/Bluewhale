using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.community
{
    public class CommunityBlock
    {
        private string _blockID;
        private string _blckname;
        private int _blcknoflrs;
        private int _blcknoflts;
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string BlockID { get => _blockID; set => _blockID = "BckID_" + value; }
        public string Blckname { get => _blckname; set => _blckname = value; }
        public int NumberofFloors { get => _blcknoflrs; set => _blcknoflrs = value; }
        public int NumberofFlats { get => _blcknoflts; set => _blcknoflts = value; }
 
        public ICollection<CommunityFlats> Flats { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }
    }
}
