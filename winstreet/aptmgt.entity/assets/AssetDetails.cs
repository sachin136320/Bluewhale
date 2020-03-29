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

        public string Name { get; set; }        
        public string Type { get; set; } //General Purpose, Eletrical etc
        public string Category { get; set; } //Hazardous, Toxic, NonToxic


        public string Description { get; set; }
        public string ActualCost {get; set;}
        public string Notes {get; set;} //if cancelled then why.. or any other notes


        public DateTime InsertDateTime { get; set; }
        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; }

        public string AssetRequestId { get; set; }
        [ForeignKey("AssetRequestId")]
        public AssetRequest AssetRequest { get; set; }
    }
}
