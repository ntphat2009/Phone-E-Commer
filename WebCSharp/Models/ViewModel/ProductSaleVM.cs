using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCSharp.Models.EntityFrameWork;

namespace WebCSharp.Models.ViewModel
{
    public class ProductSaleVM
    {
        public Product Product { get; set; }
        public ProductSale ProductSale { get; set; }
        public string Modification { get; set; }
    }
}