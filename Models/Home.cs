using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuxuryMVC.Models
{
    public class Home
    {
        public  int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string SubTitle2 { get; set; }

        public IEnumerable<Offer> Offers { get; set; }

        public bool DisplayOffers { get; set; }
    }
}