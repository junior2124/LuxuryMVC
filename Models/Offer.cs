using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuxuryMVC.Models
{
    public class Offer
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Desc1 { get; set; }
        
        public string Desc2 { get; set; }
        
        public string Desc3 { get; set; }
        
        public string Desc4 { get; set; }

        public string Price { get; set; }

        public string Interval { get; set; }

        public string Link { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public IEnumerable<Template> Templates { get; set; }

        public Template Template { get; set; }

        public byte TemplateId { get; set; }
    }
}