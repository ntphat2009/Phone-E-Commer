using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Contact")]
    public class Contact:CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string User_Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(150, ErrorMessage = "Email được vượt quá 150 ký tự")]
        public string Email { get; set; }
        [Required(ErrorMessage = "SDT không được để trống")]
        [StringLength(20, ErrorMessage = "SDT được vượt quá 20 ký tự")]
        public string Phone { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Replay_id { get; set; }

        public int Sort_Order { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }


        public bool Status { get; set; }
    }
}