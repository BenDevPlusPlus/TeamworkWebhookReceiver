using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkToAce.Models
{
    public class TeamworkAgency
    {
        public TeamworkAgency()
        {
            this.company = new Company();
            this.category = new Category();
        }

        public TeamworkAgency(TeamworkAgency old)
        {
            this.id = old.id;
            this.company = old.company;
            this.starred = old.starred;
            this.name = old.name;
            this.showAnnouncement = old.showAnnouncement;
            this.announcement = old.announcement;
            this.description = old.description;
            this.status = old.status;
            this.createdOn = old.createdOn;
            this.category = old.category;
            this.startPage = old.startPage;
            this.logo = old.logo;
            this.startDate = old.startDate;
            this.notifyEveryone = old.notifyEveryone;
            this.lastChangedOn = old.lastChangedOn;
            this.endDate = old.endDate;
            this.harvestTimersEnabled = old.harvestTimersEnabled;
            this.error = old.error;
        }

        public int id { get; set; }
        public Company company { get; set; }
        public bool? starred { get; set; } //nullable
        public string name { get; set; }
        public bool? showAnnouncement { get; set; } //nullable
        public string announcement { get; set; } //nullable
        public string description { get; set; } //nullable
        public string status { get; set; } //nullable
        public DateTime? createdOn { get; set; } //nullable
        public Category category { get; set; }
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