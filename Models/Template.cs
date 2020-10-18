using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxuryMVC.Models
{
    public class Template
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowHtml]
        public string BodyText { get; set; }
    }
}