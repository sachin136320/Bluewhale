using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aptmgt.entity.builder
{
    public class Builder
    {
        private string _builderId;
        private string _name;
        private string _address;
        private string _pincode;
        private string _state;
        private string _city;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string BuilderId { get => _builderId; set => _builderId = "BID_" + value; }
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Pincode { get => _pincode; set => _pincode = value; }
        public string State { get => _state; set => _state = value; }
        public string City { get => _city; set => _city = value; }
        public ICollection<community.CommunityDetails> Communities { get; set; }

    }
}