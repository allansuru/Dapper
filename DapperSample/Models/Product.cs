﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperSample.Model 
{
    public class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        public string QuantityPerUnit { get; set; }
        public int SupplierID { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }

        public Supplier Supplier { get; set; }
    }
}
