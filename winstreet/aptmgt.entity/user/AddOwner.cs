using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{
    public class AddOwner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        

        private string _fname;
        private string _lname;
        private string _blckname;
        private string _fltno;
        [Key]
        private int _mobno;
        [Key]
        private string _email;
        private byte[] _ownrpic;
        private byte[] _ownrqr;

        private string _ocutype;

        public string Fname { get => _fname; set => _fname = value; }
        public string Lname { get => _lname; set => _lname = value; }
        public string Blckname { get => _blckname; set => _blckname = value; }
        public string Fltno { get => _fltno; set => _fltno = value; }
        public int Mobno { get => _mobno; set => _mobno = value; }
        public string Email { get => _email; set => _email = value; }
        public byte[] Ownrpic { get => _ownrpic; set => _ownrpic = value; }
        public byte[] Ownrqr { get => _ownrqr; set => _ownrqr = value; }
        public string Ocutype { get => _ocutype; set => _ocutype = value; }
    }
}
