using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDotNet.Models
{
    public class PhoneNumbersModel
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
    }
}