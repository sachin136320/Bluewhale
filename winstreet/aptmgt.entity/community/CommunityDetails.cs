using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aptmgt.entity.community
{
    public class CommunityDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Key]
        private string commID;
        private string _bldrname;
        private string _aptname;
        private string _aptadress;
        private string _state;
        private string _city;
        private int _pincode;

        public int Pincode { get => _pincode; set => _pincode = value; }
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string Aptadress { get => _aptadress; set => _aptadress = value; }
        public string Aptname { get => _aptname; set => _aptname = value; }
        public string Bldrname { get => _bldrname; set => _bldrname = value; }
        public string CommID { get => commID; set => commID = value; }







    }
}
