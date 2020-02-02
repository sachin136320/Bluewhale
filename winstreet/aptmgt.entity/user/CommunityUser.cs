using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace aptmgt.entity.user
{
    public class CommunityUser
    {
        //to store one to many relation between user and communities
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
 
        public string UserID { get; set; }
        public string CommunityID { get; set; }


    }
}
