using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.poll
{
    public class response
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ResponseID { get => _responseID; set => _responseID = value; }
        public string QuestionID { get => _questionID; set => _questionID = value; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int PollID { get => _pollID; set => _pollID = value; }
        public string PollName { get => _pollName; set => _pollName = value; }
        public string PollResponse { get => _pollResponse; set => _pollResponse = value; }
        public string User { get => _user; set => _user = value; }

        [Key]
        private int _responseID;
        private string _questionID;
        private string commid;
        private DateTime _currdate;
        private int _pollID;
        private string _pollName;
        private string _pollResponse;
        private string _user;
    }
}
