using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BaseDb
    {
        protected readonly string _connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\tally\Documents\temp.accdb";
        protected string _tableName;
        public BaseDb(string tableName)
        {
            _tableName = tableName;
        }
    }
}
