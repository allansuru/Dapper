﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperSample.Model 
 {
    public class Supplier 
    {
        public int? SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int[] ids { get; set; }



        //  public IEnumerable<Product> Products { get; set; }
    }

    

}