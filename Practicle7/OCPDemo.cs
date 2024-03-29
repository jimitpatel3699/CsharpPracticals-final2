﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle7
{

    //create demo for OCP (open close priciple of s/w design) 
    // ocp suggests that class/module are open for extention and close for modification  
     interface Invoice
     {
        double GetInvoiceDiscount(double amount);        
     }
    internal class FinalInvoice : Invoice
    {
        public double GetInvoiceDiscount(double amount)
        {
            return (amount-10) - 50;
        }
    }
    public class ProposedInvoice : Invoice
    {
        public double GetInvoiceDiscount(double amount)
        {
            return (amount - 10) - 40;
        }
    }
    public class RecurringInvoice : Invoice
    {
        public double GetInvoiceDiscount(double amount)
        {
            return (amount - 10) - 30;
        }
    }
}
