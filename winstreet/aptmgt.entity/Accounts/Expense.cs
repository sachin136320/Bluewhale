using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aptmgt.entity.Accounts
{
   public class Expense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Commid { get => commid; set => commid = value; }
        public DateTime Currdate { get => _currdate; set => _currdate = value; }
        public int TranID { get => _tranID; set => _tranID = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public string ExpenseType { get => _expenseType; set => _expenseType = value; }
        public string Description { get => _description; set => _description = value; }

        private string commid;
        private DateTime _currdate;
        private int _tranID;
        private int _amount;
        private string _expenseType;
        private string _description;
    }
}
