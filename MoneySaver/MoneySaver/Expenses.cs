using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySaver
{
    class Expenses : IExpenses
    {
        [PrimaryKey, AutoIncrement]
        
        public int Id { get; set; }
       
        public string Amount { get; set; } 

        public string Name { get; set; }
    }
}