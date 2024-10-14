using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Product")]

    public class Product:CommonAbstract
    {
        public Product() {
            this.ProductImages = new HashSet<ProductImage>();

            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductSale = new HashSet<ProductSale>();

            //this.ProductStore = new HashSet<ProductStore>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã danh mục không được để trống")]
       
        public int CategoryId { get; set; }
        //[Required(ErrorMessage = "Mã danh mục không được để trống")]

        //public int ProductSaleId { get; set; }
        [Required(ErrorMessage = "Mã thương hiệu không được để trống")]
       
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        public decimal Price { get; set; }

       
        [AllowHtml]
        public string Detail { get; set; }

        public int Sort_Order { get; set; }
        [Required(ErrorMessage = "Metakey không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metakey { get; set; }
        [Required(ErrorMessage = "Metadesc không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metadesc { get; set; }
        public bool isHot { get; set; }
        public bool isHome { get; set; }
        
        public bool isFeature { get; set; }


        public bool Status { get; set; }

        //public virtual Product Products { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductSale> ProductSale { get; set; }

        //public virtual ICollection<ProductStore> ProductStore { get; set; }

        public virtual Category Category { get; set; }
        //public virtual ProductSale ProductSale { get; set; }


    }
}