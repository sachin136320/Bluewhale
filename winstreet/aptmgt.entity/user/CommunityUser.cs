using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace aptmgt.entity.user
{
    public class CommunityUser
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        private string _userID;
        public string UserID { get => _userID; set => _userID = value; }
        public string CommunityID { get; set; }


    }
}
