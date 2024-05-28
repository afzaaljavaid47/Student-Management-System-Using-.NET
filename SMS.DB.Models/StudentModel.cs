using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMS.DB.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string f_name { get; set; }
        [AllowHtml]
        public string address { get; set; }
        public int className { get; set; }
    }
}
