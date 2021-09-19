using System;
using System.Collections.Generic;
using System.Text;

namespace InvoicesManager
{
    public class exp
    {
        public double Price;
        public DateTime Date;
        public string Exptype;

        public exp(double pr, DateTime d, string etype)
        {
            Date = d;
            Price = pr;
            Exptype = etype;
        }
    }
}
