using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.poll
{
    public class Poll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string PollID { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime Currdate { get; set; }
        public string PollName { get; set; }
        public DateTime PollStart { get; set; }
        public DateTime PollEnd { get; set; }
        public string IsOpen { get; set; }

    }
}
