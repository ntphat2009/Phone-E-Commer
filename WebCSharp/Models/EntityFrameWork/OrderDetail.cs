using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_OrderDetail")]

    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }


        public double Price { get; set; }
        public int Qty { get; set; }

        public double Amount { get; set; }

        public bool Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Products { get; set; }
    }
}