using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.community
{
    public class CommunityBlock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        private String commID;
        private string _blckname;
        private int _blcknoflrs;
        private int _blcknoflts;

        public string CommID { get => commID; set => commID = value; }
        public string Blckname { get => _blckname; set => _blckname = value; }
        public int Blcknoflrs { get => _blcknoflrs; set => _blcknoflrs = value; }
        public int Blcknoflts { get => _blcknoflts; set => _blcknoflts = value; }



        

        


    }
}
