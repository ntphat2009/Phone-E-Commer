using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_ProductStore")]
    public class ProductStore : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã chủ đề không được để trống")]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }

        public virtual Product Product { get; set; }

    }

   
}