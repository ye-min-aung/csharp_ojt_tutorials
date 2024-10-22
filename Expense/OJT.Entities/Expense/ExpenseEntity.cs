using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJT.Entities.Expense
{
    public class ExpenseEntity
    {
        public int expenseId {  get; set; }
        public string expenseName { get; set; }
        public string category {  get; set; }
        public string date { get; set; }
        public string person { get; set; }
    }
}
