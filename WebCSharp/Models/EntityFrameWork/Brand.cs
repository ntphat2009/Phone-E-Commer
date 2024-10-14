using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Brand")]
    public class Brand
    {
        public Brand() { 
        this.Product = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên không được để trống")]
        [StringLength(150,ErrorMessage ="Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        
        public string Slug { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Sort_order kkhông được để trống")]
        [DefaultValue(0)]
        public int Sort_Order { get; set; }
        [Required(ErrorMessage = "Metakey không được để trống")]
        public string Metakey { get; set; }
        [Required(ErrorMessage = "Metadesc không được để trống")]
        public string Metadesc { get; set; }

        public bool Status { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}