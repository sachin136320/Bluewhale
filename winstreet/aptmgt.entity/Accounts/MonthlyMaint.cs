using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
    public class MonthlyMaint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int TranID { get => _tranID; set => _tranID = value; }
        public string Fltno { get => _fltno; set => _fltno = value; }
        public string OwnerName { get => _ownerName; set => _ownerName = value; }
        public string Email { get => _email; set => _email = value; }
        public int Mobno { get => _mobno; set => _mobno = value; }

        private string commid;
        private DateTime _currdate;
        private int _tranID;
        private string _fltno;
        private string _ownerName;
        private string _email;
        private int _mobno;
    }

}
