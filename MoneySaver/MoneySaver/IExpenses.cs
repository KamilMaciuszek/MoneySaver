using System;
using System.Collections.Generic;
using System.Text;

namespace MoneySaver
{
    interface IExpenses
    {
        int Id { get; set; }
        string Name { get; set; }
        string Amount { get; set; }
        double TotalExpenses { get; set; }
    }
}
