using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace aptmgt.entity.facility
{
    public class FacilityMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        private string commId;
        private string _facility_name;
        private string _bkable;

        public string CommId { get => commId; set => commId = value; }
        public string Bkable { get => _bkable; set => _bkable = value; }
        public string Facility_name { get => _facility_name; set => _facility_name = value; }
    }
}