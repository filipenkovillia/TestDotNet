﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestDotNet.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Adress Book ID")]
        public int AddressID { get; set; }
    }
}