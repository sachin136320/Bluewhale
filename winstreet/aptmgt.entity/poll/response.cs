using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.poll
{
    public class PollResponse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string PollResponseID { get; set; }
        public string PollName { get; set; }
        public string Response { get; set; }

        public DateTime InsertDateTime { get; set; }

        public string User { get; set; } // this should be resident id

        public string PollQuestionID { get; set; }
        [ForeignKey("PollQuestionID")]
        public PollQuestion PollQuestion { get; set; }

        public string CommunityID { get; set; }
        [ForeignKey("CommunityID")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public string PollID { get; set; }
        [ForeignKey("PollID")]
        public Poll Poll { get; set; }

         
    }
}
