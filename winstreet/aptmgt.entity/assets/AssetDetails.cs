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
        public string AssetId { get; set; }

        public string AssetName { get; set; }
        public string Purpose { get; set; }
        public string Cost {get; set;}
        public string RequestDate {get; set;}
        public string RequestStatus {get; set;} //Open, Closed
        public string AssestStatus {get; set;} //InProgress, Procured, Cancelled, Approved, Rejected

        public string AssetType { get; set; } //General Purpose, Eletrical etc
        public string AssetCategory { get; set; } //Hazardous, Toxic, NonToxic
        public DateTime AssetProcureDate { get; set; }
        public DateTime AssetApproveDate { get; set; }
        public string Notes {get; set;} //if cancelled then why.. or any other notes

        public bool AssetRequireServiceFlag { get; set; } 
        
        public DateTime InsertDateTime { get; set; }
        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }


    }
}
