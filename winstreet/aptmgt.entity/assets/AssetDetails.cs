/*
CREATE TABLE `aptasset` (
  `aptassetid` int(11) NOT NULL AUTO_INCREMENT,
  `aptassetnr` varchar(45) NOT NULL,
  `aptassetname` varchar(45) NOT NULL,
  `aptassettype` varchar(45) NOT NULL,
  `aptassetcat` varchar(45) NOT NULL,
  `aptassetsrvcfrq` varchar(45) DEFAULT NULL,
  `aptassetlstsrvc` date DEFAULT NULL,
  `aptassetimg` blob,
  `aptassetsrvcflag` varchar(45) DEFAULT NULL,
  `aptassetprdate` date DEFAULT NULL,
  `datechng` date DEFAULT NULL,
  `srvcrdmnt` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`aptassetid`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class AssetDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        private int _assetId;
        private string _asset_NR;
        private string commid;
        private DateTime _currdate;
        private byte[] _asset_qr_img;
        private DateTime _asset_last_servce;
        private string _asset_service_Freq;
        private string _asset_category;
        private string _asset_Type;
        private string _asset_name;
        private string _asset_service_flag;
        private DateTime _asset_procure_Date;



        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public string Asset_NR { get => _asset_NR; set => _asset_NR = value; }
        public string Asset_name { get => _asset_name; set => _asset_name = value; }
        public string Asset_Type { get => _asset_Type; set => _asset_Type = value; }
        public string Asset_category { get => _asset_category; set => _asset_category = value; }
        public string Asset_service_Freq { get => _asset_service_Freq; set => _asset_service_Freq = value; }
        public DateTime Asset_last_servce { get => _asset_last_servce; set => _asset_last_servce = value; }
        public byte[] Asset_qr_img { get => _asset_qr_img; set => _asset_qr_img = value; }
        public string Asset_service_flag { get => _asset_service_flag; set => _asset_service_flag = value; }
        public DateTime Asset_procure_Date { get => _asset_procure_Date; set => _asset_procure_Date = value; }
        public int AssetId { get => _assetId; set => _assetId = value; }
    }
}
