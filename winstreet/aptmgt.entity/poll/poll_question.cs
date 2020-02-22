using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.poll
{
    public class PollQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string PollQuestionID { get; set; }

        public DateTime InsertDateTime { get; set; }
        public string PollName { get; set; }
        public string Question { get; set; }
         
        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public string PollID { get; set; }
        [ForeignKey("PollID")]
        public Poll Poll { get; set; }

    }
}
