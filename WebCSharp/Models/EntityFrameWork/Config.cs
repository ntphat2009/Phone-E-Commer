using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


	

namespace WebCSharp.Models.EntityFrameWork
    {
        [Table("2121110054_Config")]
        public class Config : CommonAbstract
        {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required(ErrorMessage = "Tên không được để trống")]
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Author { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Email { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Phone { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Zalo { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Facebook { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Address { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Youtube { get; set; }
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            [Required(ErrorMessage = "Metakey không được để trống")]
            public string Metakey { get; set; }
            [Required(ErrorMessage = "Metadesc không được để trống")]
            [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
            public string Metadesc { get; set; }

            public bool Status { get; set; }


        }
    }
