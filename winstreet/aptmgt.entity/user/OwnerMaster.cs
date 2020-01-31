using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class OwnerMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OwnerID { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BlockID { get; set; }
        public string FlatNumber { get; set; }
        public string Occupied { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public byte[] OwnerPicture { get; set; }
        public string OwnerQRText { get; set; }
        public DateTime OwnerAddDate { get; set; }
        public string Active { get; set; }
        
    }
}