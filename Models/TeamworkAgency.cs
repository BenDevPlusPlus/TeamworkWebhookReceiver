using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkWebhookApi.Models
{
    public class TeamworkAgency
    {
        public TeamworkAgency()
        {
        }

        public int id { get; set; }
        public string companyName { get; set; } //nullabel
        public int? companyId { get; set; } //nullable
        public bool? starred { get; set; } //nullable
        public string name { get; set; }
        public bool? showAnnouncement { get; set; } //nullable
        public string announcement { get; set; } //nullable
        public string description { get; set; } //nullable
        public string status { get; set; } //nullable
        public DateTime? createdOn { get; set; } //nullable
        public string categoryName { get; set; } //nullable
        public int? categoryId { get; set; } //nullable
        public string startPage { get; set; } //nullable
        public string logo { get; set; } //nullable
        public DateTime? startDate { get; set; } //nullable
        public bool? notifyEveryone { get; set; } //nullable
        public DateTime? lastChangedOn { get; set; } //nullable
        public DateTime? endDate { get; set; } //nullable
        public bool? harvestTimersEnabled { get; set; } //nullable
        public string error { get; set; }
    }
}