using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aptmgt.entity.builder
{
    public class Builder
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string BuilderId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public ICollection<community.CommunityDetails> Communities { get; set; }

    }
}