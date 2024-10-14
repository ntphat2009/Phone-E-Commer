using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCSharp.Models
{
    public abstract class CommonAbstract
    {
        public int Create_By { get; set; }
        public int Update_By { get; set; }

        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
    }
}