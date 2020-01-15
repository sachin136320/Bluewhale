using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aptmgt.entity.community
{
    public class CommunityDetails
    {
       
        private string commID; 
        private string _aptname;
        private string _aptadress;
        private string _state;
        private string _city;
        private int _pincode;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string CommID { get => commID; set => commID = "CID_" + value; }
        public string Name { get => _aptname; set => _aptname = value; }
        public string Address { get => _aptadress; set => _aptadress = value; }
        public string State { get => _state; set => _state = value; }
        public string City { get => _city; set => _city = value; }
        public int Pincode { get => _pincode; set => _pincode = value; }
        public string BuilderID { get; set; }
        [ForeignKey("BuilderID")]
        public builder.Builder Builder { get; set; }
        public ICollection<CommunityBlock> Blocks { get; set; }
    }
}
