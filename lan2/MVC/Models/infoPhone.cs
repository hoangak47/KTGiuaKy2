using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class infoPhone
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public Nullable<double> Price { get; set; }
        public string GeneralNote { get; set; }
    }
}