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
    [Table("2121110054_Post")]

    public class Post : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã chủ đề không được để trống")]
        //[ForeignKey("Topic_Id")]
        public int TopicId { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]

        public string Title { get; set; }
        public string Slug { get; set; }
        [AllowHtml]
        public string Detail { get; set; }

        public string Image { get; set; }
        public string Type { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }
        public bool Status { get; set; }
        public virtual Topic Topic { get; set; }

    }
}