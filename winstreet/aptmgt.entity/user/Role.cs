using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ID { get; set; }
        public string Rolename { get; set; }
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