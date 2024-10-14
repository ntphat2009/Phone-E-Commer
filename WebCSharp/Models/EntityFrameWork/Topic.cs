using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Topic")]
    public class Topic : CommonAbstract
    {
        public Topic()
        {
            this.Post = new HashSet<Post>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }

        public string Slug { get; set; }
        [Required(ErrorMessage = "Mã cấp cha không được để trống")]
        public int Parent_Id { get; set; }
        [Required(ErrorMessage = "Metakey không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metakey { get; set; }
        [Required(ErrorMessage = "Metadesc không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metadesc { get; set; }
        public bool Status { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}