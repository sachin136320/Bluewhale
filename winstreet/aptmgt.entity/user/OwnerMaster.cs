using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class OwnerMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       

        private string _fname;
        private string _lname;
        private string _blckname;
        private string _fltno;
        private string _occupied;
        [Key]
        private int _mobno;
        [Key]
        private string _email;
        private byte[] _ownrpic;
        private byte[] _ownrqr;
        private DateTime _ownradddate;
        private string _active;



        public string Fname { get => _fname; set => _fname = value; }
        public string Lname { get => _lname; set => _lname = value; }
        public string Blckname { get => _blckname; set => _blckname = value; }
        public string Fltno { get => _fltno; set => _fltno = value; }
        public string Occupied { get => _occupied; set => _occupied = value; }
        public int Mobno { get => _mobno; set => _mobno = value; }
        public string Email { get => _email; set => _email = value; }
        public byte[] Ownrpic { get => _ownrpic; set => _ownrpic = value; }
        public byte[] Ownrqr { get => _ownrqr; set => _ownrqr = value; }
        public DateTime Ownradddate { get => _ownradddate; set => _ownradddate = value; }
        public string Active { get => _active; set => _active = value; }
        
        
    }
}