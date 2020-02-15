using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace aptmgt.entity.user
{

    public class Resident
    {
        private byte[] picture;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResidentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BlockID { get; set; }
        public string CommID { get; set; }
        public string FlatNumber { get; set; }
        public bool Occupied { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Picture
        {
            get => Encoding.ASCII.GetString(picture);
            set => picture = Encoding.ASCII.GetBytes(value);
        }
        public string QRText { get; set; }
        public DateTime AddDate { get; set; }
        public bool Active { get; set; }
        public string notes { get; set; }
    }
}