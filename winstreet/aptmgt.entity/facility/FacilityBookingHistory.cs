using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.facility
{

    public class FacilityBookingHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        private string commid;
        private DateTime _currdate;

        private string _booking_ID;
        private DateTime _booking_date;
        private DateTime _booking_start_time;
        private DateTime _booking_end_time;
        private string _owner_flatno;
        private string _owner_name;
        private string _booking_facility;
        private int _booking_duration;
        private string _booking_description;
        private string _booking_status;


        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public string Booking_ID { get => _booking_ID; set => _booking_ID = value; }
        public DateTime Booking_date { get => _booking_date; set => _booking_date = value; }
        public DateTime Booking_start_time { get => _booking_start_time; set => _booking_start_time = value; }
        public DateTime Booking_end_time { get => _booking_end_time; set => _booking_end_time = value; }
        public string Owner_flatno { get => _owner_flatno; set => _owner_flatno = value; }
        public string Owner_name { get => _owner_name; set => _owner_name = value; }
        public string Booking_facility { get => _booking_facility; set => _booking_facility = value; }
        public int Booking_duration { get => _booking_duration; set => _booking_duration = value; }
        public string Booking_description { get => _booking_description; set => _booking_description = value; }
        public string Booking_status { get => _booking_status; set => _booking_status = value; }
    }

}