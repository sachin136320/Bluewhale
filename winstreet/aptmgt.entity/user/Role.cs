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
/*
const MemberShipTypes = [
    {
      value: 'President',
      label: 'President',
    },
    {
      value: 'Vice Persident/Secretary',
      label: 'Vice Persident/Secretary',
    },
    {
      value: 'Working committee member',
      label: 'Working committee member',
    },
    {
      value: 'Tresasure',
      label: 'Tresasure',
    },
    {
        value: 'Community Member',
        label: 'Community Member',
      },
    {
      value: 'Not Applicable',
      label: 'Not Applicable',
    },
  ];
   */