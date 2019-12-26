using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        private string _roleID;
        private string _rolename;
        public string RoleID { get => _roleID; set => _roleID = value; }
        public string Rolename { get => _rolename; set => _rolename = value; }
    }
}