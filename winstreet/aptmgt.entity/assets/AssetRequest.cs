using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.assets
{
    public class AssetRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        private string commid;
        private DateTime _currdate;

        private string _asset_Name;
        private string _asset_Purpose;
        private string _asset_cost;
        private DateTime _requestDate;
        [Key]
        private string _requestID;
        private string _requeststatus;
        private string _procurestatus;
        private string _procure_approval;
        private string _ast_added;


        public string Asset_Name { get => _asset_Name; set => _asset_Name = value; }
        public string Asset_Purpose { get => _asset_Purpose; set => _asset_Purpose = value; }
        public string Asset_cost { get => _asset_cost; set => _asset_cost = value; }
        public DateTime RequestDate { get => _requestDate; set => _requestDate = value; }
        public string RequestID { get => _requestID; set => _requestID = value; }
        public string Requeststatus { get => _requeststatus; set => _requeststatus = value; }
        public string Procurestatus { get => _procurestatus; set => _procurestatus = value; }
        public string Procure_approval { get => _procure_approval; set => _procure_approval = value; }
        public string Ast_added { get => _ast_added; set => _ast_added = value; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }

    }
}
