using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamworkWebhookApi.Models;
using System.Data;
using System.Data.SqlClient;
using TeamworkWebhookApi.Tools;

namespace TeamworkWebhookApi.DataProviders
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

        public string Create(AceAgency agency)
        {
            string result = "";

            using(var database = this.GetConnection())
            {
                using(var transaction = database.Conn.BeginTransaction())
                {
                    try
                    {
                        string query = $"INSERT INTO [ACE_Repository].[dbo].[Agency] VALUES ({agency.Agency_Id}, '{agency.Agency_Name}', {agency.Agency_Enable}, '{agency.ImpItContactName}', '{agency.ImpProtocolVersion}', '{agency.ImpAquaVersion}', '{agency.ImpQaStandardsVersion}', '{agency.ImpCad}', '{agency.ImpCadVersion}', {agency.ImpCadCertified}, {agency.ImpCurrentAce}, {agency.ImpAcePrePaid}, {agency.InternalAgencyId}, '{agency.ImpConsultantUserId}', {agency.ImplementationType}, {agency.ParentAgency_Id}, {agency.Master_Agency_Id}, {agency.IsActive}, {agency.DiscHash});";
                        var cmd = new SqlCommand(query, database.Conn);
                        int numRows = cmd.ExecuteNonQuery();
                        if (numRows == 1)
                        {
                            transaction.Commit();
                            result = "success";
                        }
                    } catch(Exception ex)
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