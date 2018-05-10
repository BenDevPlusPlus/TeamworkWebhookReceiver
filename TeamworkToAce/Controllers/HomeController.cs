using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamworkToAce.DataProviders;
using TeamworkToAce.Models;

namespace TeamworkToAce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var provider = new TeamworkAgencyDataProvider();

            List<TeamworkAgency> agencies = provider.ReadAll();

            ViewBag.Title = "Home Page";
            ViewBag.teamAgencyList = agencies;

            return View();
        }

        [HttpPost]
        public string saveAceAgency(int teamworkId, string ImpItContactName, string ImpProtocolVersion, string ImpQaStandardsVersion, string ImpAquaVersion, string ImpCad, string ImpCadVersion, bool ImpCadCertified, bool ImpCurrentAce, bool ImpAcePrepaid, int? InternalAgencyId, int ImplementationType)
        {
            string result = "";

            var teamProvider = new TeamworkAgencyDataProvider();
            TeamworkAgency teamworkAgency = teamProvider.Read(teamworkId);

            var aceProvider = new AceProjectDataProvider();
            AceAgency aceAgency = new AceAgency();
            aceAgency.Agency_Name = teamworkAgency.name;
            aceAgency.Agency_Enable = true;
            if (ImplementationType == 2)
            {
                aceAgency.DiscHash = 1;
            }
            else if (ImplementationType == 4)
            {
                aceAgency.DiscHash = 2;
            }
            else if (ImplementationType == 8)
            {
                aceAgency.DiscHash = 4;
            }
            else if (ImplementationType == 16)
            {
                aceAgency.DiscHash = 8;
            }
            else
            {
                aceAgency.DiscHash = 0;
            }
            aceAgency.ImpAcePrePaid = ImpAcePrepaid;
            aceAgency.ImpAquaVersion = ImpAquaVersion;
            aceAgency.ImpCad = ImpCad;
            aceAgency.ImpCadCertified = ImpCadCertified;
            aceAgency.ImpCadVersion = ImpCadVersion;
            aceAgency.ImpCurrentAce = ImpCurrentAce;
            aceAgency.ImpItContactName = ImpItContactName;
            aceAgency.ImplementationType = ImplementationType;
            aceAgency.ImpProtocolVersion = ImpProtocolVersion;
            aceAgency.ImpQaStandardsVersion = ImpQaStandardsVersion;
            if (InternalAgencyId.HasValue)
            {
                aceAgency.InternalAgencyId = InternalAgencyId;
            }
            else
            {
                aceAgency.InternalAgencyId = 0;
            }
            aceAgency.IsActive = true;
            aceAgency.Master_Agency_Id = 0;
            aceAgency.ParentAgency_Id = 0;

            result = aceProvider.Create(aceAgency);

            return result;
        }

        [HttpPost]
        public string removeTeamworkAgency(int id)
        {
            string result = "";

            var provider = new TeamworkAgencyDataProvider();
            provider.Delete(id);

            return result;
        }
    }
}
