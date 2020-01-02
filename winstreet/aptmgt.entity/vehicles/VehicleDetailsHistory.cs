using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.vehicles
{
    public class VehicleDetailsHistory
    {

        public int ID { get; set; }


        private string commid;
        private DateTime _currdate;
        private string _vehicle_ID;
        private string _owner_fname;
        private string _owner_lname;
        private string _owner_flatno;
        private int _owner_phno;
        private string _owner_email;
        private string _owner_slotno;
        private string _vehicle_no;

        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public string Vehicle_ID { get => _vehicle_ID; set => _vehicle_ID = value; }
        public string Owner_fname { get => _owner_fname; set => _owner_fname = value; }
        public string Owner_lname { get => _owner_lname; set => _owner_lname = value; }
        public string Owner_flatno { get => _owner_flatno; set => _owner_flatno = value; }
        public int Owner_phno { get => _owner_phno; set => _owner_phno = value; }
        public string Owner_email { get => _owner_email; set => _owner_email = value; }
        public string Owner_slotno { get => _owner_slotno; set => _owner_slotno = value; }
        public string Vehicle_no { get => _vehicle_no; set => _vehicle_no = value; }
    }
}
