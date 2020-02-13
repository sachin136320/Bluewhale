using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
    public class TransactionMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        private int _tranID;

        private string commid;
        private DateTime _currdate;
        private int _accountId;
        private int _amount;
        private string _tranType;
        private DateTime _timestamp;

        public int TranID { get => _tranID; set => _tranID = value; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int AccountId { get => _accountId; set => _accountId = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public string TranType { get => _tranType; set => _tranType = value; }
        public DateTime Timestamp { get => _timestamp; set => _timestamp = value; }
    }
}
