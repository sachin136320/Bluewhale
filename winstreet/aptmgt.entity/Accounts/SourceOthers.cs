using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
    public class SourceOthers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int TranID { get => _tranID; set => _tranID = value; }
        public string SourceName { get => _sourceName; set => _sourceName = value; }

        private string commid;
        private DateTime _currdate;
        private int _tranID;
        private string _sourceName;
    }
}
