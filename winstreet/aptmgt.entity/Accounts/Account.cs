using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        private int _accountId;
        private string commid;
        private DateTime _currdate;
        private string _accountType;
        private int _accountno;
        private string _bankname;
        private int _currntBalance;
        private DateTime _dateadded;

        public int AccountId { get => _accountId; set => _accountId = value; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public string AccountType { get => _accountType; set => _accountType = value; }
        public int Accountno { get => _accountno; set => _accountno = value; }
        public string Bankname { get => _bankname; set => _bankname = value; }
        public int CurrntBalance { get => _currntBalance; set => _currntBalance = value; }
        public DateTime Dateadded { get => _dateadded; set => _dateadded = value; }
    }
}
