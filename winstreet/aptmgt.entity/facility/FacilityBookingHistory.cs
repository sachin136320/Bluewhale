using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.facility
{

    public class FacilityBookingHistory
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string FacilityBookingHistoryID { get; set; }


        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime Currdate { get; set; }
        public string Booking_ID { get; set; }
        public DateTime Booking_date { get; set; }
        public DateTime Booking_start_time { get; set; }
        public DateTime Booking_end_time { get; set; }
        public string Owner_flatno { get; set; }
        public string Owner_name { get; set; }
        public string Booking_facility { get; set; }
        public string Booking_duration { get; set; }
        public string Booking_description { get; set; }
        public string Booking_status { get; set; }
    }

}