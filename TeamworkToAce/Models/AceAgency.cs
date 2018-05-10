using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkToAce.Models
{
    public class AceAgency
    {
        public AceAgency()
        {
        }

        public int? Agency_Id { get; set; }
        public string Agency_Name { get; set; }
        public bool Agency_Enable { get; set; }
        public string ImpItContactName { get; set; } //nullable
        public string ImpProtocolVersion { get; set; } //nullable
        public string ImpAquaVersion { get; set; } //nullable
        public string ImpQaStandardsVersion { get; set; } //nullable
        public string ImpCad { get; set; } //nullable
        public string ImpCadVersion { get; set; } //nullable
        public bool? ImpCadCertified { get; set; } //nullable
        public bool? ImpCurrentAce { get; set; } //nullable
        public bool? ImpAcePrePaid { get; set; } //nullable
        public int? InternalAgencyId { get; set; } //nullable
        public string ImpConsultantUserId { get; set; } //nullable
        public int? ImplementationType { get; set; } //nullable
        public int? ParentAgency_Id { get; set; } //nullable
        public int? Master_Agency_Id { get; set; } //nullable
        public bool IsActive { get; set; }
        public int DiscHash { get; set; }
    }
}