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
        [Key]
        public string AssetId {get; set;}

        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public DateTime Currdate { get; set; }
        public string Asset_NR { get; set; }
        public string Asset_name { get; set; }
        public string Asset_Type { get; set; }
        public string Asset_category { get; set; }
        public string Asset_service_Freq { get; set; }
        public DateTime Asset_last_servce { get; set; }
        public string Asset_service_flag { get; set; }
        public DateTime Asset_procure_Date { get; set; }
    }
}
