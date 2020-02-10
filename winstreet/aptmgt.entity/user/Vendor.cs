using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class Vendor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ID { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public string QRText { get; set; }
        public DateTime AddDate { get; set; }
        public string Active { get; set; }
        public string JobProfile {get; set; }
    }
}