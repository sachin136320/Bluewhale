using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.poll
{
    public class poll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        private int _pollID;
        private string commid;
        private DateTime _currdate;
        private string _pollName;
        private DateTime _pollStart;
        private DateTime _pollEnd;
        private string _isOpen;

        public int PollID { get => _pollID; set => _pollID = value; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public string PollName { get => _pollName; set => _pollName = value; }
        public DateTime PollStart { get => _pollStart; set => _pollStart = value; }
        public DateTime PollEnd { get => _pollEnd; set => _pollEnd = value; }
        public string IsOpen { get => _isOpen; set => _isOpen = value; }

    }
}
