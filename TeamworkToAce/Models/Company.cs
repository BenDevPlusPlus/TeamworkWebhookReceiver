using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkToAce.Models
{
    public class Company
    {
        public Company()
        {

        }

        public Company(Company old)
        {
            this.name = old.name;
            this.id = old.id;
        }

        public string name { get; set; }
        public int? id { get; set; }
    }
}