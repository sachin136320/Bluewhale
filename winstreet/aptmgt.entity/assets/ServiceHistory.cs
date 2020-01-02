using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class ServiceHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        private string commid;
        private DateTime _currdate;
        private int _assetId;
        private string _asset_NR;
        private string _asset_Name;
        private string _asset_service_Freq;
        private DateTime _asset_last_servce;
        private string _asset_service_flag;
        private DateTime _asset_service_date;

        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int AssetId { get => _assetId; set => _assetId = value; }
        public string Asset_NR { get => _asset_NR; set => _asset_NR = value; }
        public string Asset_Name { get => _asset_Name; set => _asset_Name = value; }
        public string Asset_service_Freq { get => _asset_service_Freq; set => _asset_service_Freq = value; }
        public DateTime Asset_last_servce { get => _asset_last_servce; set => _asset_last_servce = value; }
        public string Asset_service_flag { get => _asset_service_flag; set => _asset_service_flag = value; }
        public DateTime Asset_service_date { get => _asset_service_date; set => _asset_service_date = value; }

    }
}
