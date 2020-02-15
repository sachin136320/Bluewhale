using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
    public class maintMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Commid { get => commid; set => commid = value; }
        public string Fltno { get => _fltno; set => _fltno = value; }
        public int MaintAmount { get => _maintAmount; set => _maintAmount = value; }

        private string commid;
        private string _fltno;
        private int _maintAmount;
    }
}
