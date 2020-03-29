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
    public class AssetRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string AssetRequestId { get; set; }

        public string Name { get; set; }
        public string Purpose { get; set; }
        public string EstimatedCost {get; set;}
        public string ActualCost {get; set;}
        public string RequestDate {get; set;}
        public string RequestStatus {get; set;} //Open, Closed
        
        public string ApprovalStatus {get; set;} 
        //Approved, Rejected
        public DateTime ApproveDate { get; set; }
        
        public string ProcurementStatus {get; set;} 
        //InProgress, Procured, Cancelled
        public DateTime ProcureDate { get; set; }


        public string Notes {get; set;} 
        //if cancelled then why.. or any other notes
        public DateTime InsertDateTime { get; set; }
        public string CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public community.CommunityDetails ParentCommunity { get; set; } 
    }
}
