using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkWebhookApi.Models
{
    public class TeamProject
    {
        public EventCreator eventCreator { get; set; }
        public Project project { get; set; }
    }
}