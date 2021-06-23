using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediCaps.API.Models
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Constituent { get; set; }
    }
}