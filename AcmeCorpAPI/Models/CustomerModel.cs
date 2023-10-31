﻿using System.ComponentModel.DataAnnotations;

namespace AcmeCorpAPI.Models
{
    public class CustomerModel
    {
        [Key] 
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
