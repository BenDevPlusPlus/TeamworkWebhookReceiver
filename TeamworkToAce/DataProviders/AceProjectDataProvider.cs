using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamworkToAce.Models;
using System.Data;
using System.Data.SqlClient;
using TeamworkToAce.Tools;

namespace TeamworkToAce.DataProviders
{
    public class AceProjectDataProvider
    {
        public string ConnectionString { get; set; }

        public AceProjectDataProvider()
        {
        }

        public AceProjectDataProvider(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            return !String.IsNullOrWhiteSpace(this.ConnectionString)
                ? new DbConnection(this.ConnectionString)
                : new DbConnection();
        }

        public AceAgency PrepareFromTeamworkAgency(TeamworkAgency teamAgency)
        {
            AceAgency agency = new AceAgency();



            return agency;
        }

        public string Create(AceAgency agency)
        {
            string result = "";

            using (var database = this.GetConnection())
            {
                using (var transaction = database.Conn.BeginTransaction())
                {
                    try
                    {
                        string query = $"INSERT INTO [ACE_Repository].[dbo].[Agency] (Agency_Name, Agency_Enable, ImpItContactName, ImpProtocolVersion, ImpAquaVersion, ImpQaStandardsVersion, ImpCad, ImpCadVersion, ImpCadCertified, ImpCurrentAce, ImpAcePrePaid, InternalAgencyId, ImplementationType, ParentAgency_Id, Master_Agency_Id, IsActive, DiscHash) VALUES ('{agency.Agency_Name}', {(agency.Agency_Enable == true ? 1 : 0)}, '{agency.ImpItContactName}', '{agency.ImpProtocolVersion}', '{agency.ImpAquaVersion}', '{agency.ImpQaStandardsVersion}', '{agency.ImpCad}', '{agency.ImpCadVersion}', {(agency.ImpCadCertified == true ? 1 : 0)}, {(agency.ImpCurrentAce == true ? 1 : 0)}, {(agency.ImpAcePrePaid == true ? 1 : 0)}, {agency.InternalAgencyId}, {agency.ImplementationType}, {agency.ParentAgency_Id}, {agency.Master_Agency_Id}, {(agency.IsActive == true ? 1 : 0)}, {agency.DiscHash});";
                        var cmd = new SqlCommand(query, database.Conn, transaction);
                        int numRows = cmd.ExecuteNonQuery();
                        if (numRows == 1)
                        {
                            transaction.Commit();
                            result = "success";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result = "Error: " + ex.Message;
                    }
                }
            }

            return result;
        }
    }
}