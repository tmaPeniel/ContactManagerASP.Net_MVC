﻿using System.ComponentModel.DataAnnotations;

namespace ContactManagerASP.NetMVC.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        
        public string Numero { get; set; }
    }
}
