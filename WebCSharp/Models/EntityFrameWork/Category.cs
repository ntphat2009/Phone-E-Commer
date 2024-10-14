using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Category")]
    public class Category: CommonAbstract
    {
        public Category() { 
        //this.Posts = new HashSet<Post>();
        this.Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        //[UniqueProductName(ErrorMessage = "Tên sản phẩm đã tồn tại.")]
       
        public string Name { get; set; }
     
        public string Slug { get; set; }
        public string Image { get; set; }

        public int Sort_Order { get; set; }
        [Required]
        public string Metakey { get; set; }
        [Required]
        public string Metadesc { get; set; }

        [Required]
        public int Parent_Id { get; set; }
    
        public bool Status { get; set; }

        //public ICollection<Post> Posts { get; set; }
        public ICollection<Product> Product { get;set; }
    }
}