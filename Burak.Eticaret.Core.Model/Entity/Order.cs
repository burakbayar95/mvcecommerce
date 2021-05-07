﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burak.Eticaret.Core.Model.Entity
{
   public class Order:EntityBase
    {
        public int UserID { get; set; }
        public int User { get; set; }
        public int UserAdressID { get; set; }
        public UserAdress UserAdress { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        public decimal TotalProductPrice { get; set; }
        public decimal  TotalTaxPrice { get; set; }
        public decimal TotalDiscount  { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual List<OrderPayment> OrderPayments { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }



    }
}
