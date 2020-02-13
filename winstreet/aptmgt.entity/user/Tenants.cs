using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.user
{

    public class Tenants : Resident
    {
        public bool AgreementCopySubmitted {get; set;}   
    }
}