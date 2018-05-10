using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkWebhookApi.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Tag> tags { get; set; }
        public int companyId { get; set; }
        public int categoryId { get; set; }
        public DateTime dateCreated { get; set; }
    }
}