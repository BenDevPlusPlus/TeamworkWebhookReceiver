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
    public class TeamworkAgencyDataProvider
    {
        public string ConnectionString { get; set; }

        public TeamworkAgencyDataProvider()
        {
        }

        public TeamworkAgencyDataProvider(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            return !String.IsNullOrWhiteSpace(this.ConnectionString)
                ? new DbConnection(this.ConnectionString)
                : new DbConnection();
        }

        public string Create(TeamworkAgency agency)
        {
            string result = "";

            using (var database = this.GetConnection())
            {
                using (var transaction = database.Conn.BeginTransaction())
                {
                    try
                    {
                        string query = $"INSERT INTO [ACE_Repository].[dbo].[TeamworkAgency] VALUES ({agency.id}, '{agency.companyName}', {agency.companyId}, {agency.starred}, '{agency.name}', {agency.showAnnouncement}, '{agency.announcement}', '{agency.description}', '{agency.status}', '{agency.createdOn.ToString()}', '{agency.categoryName}', {agency.categoryId}, '{agency.startPage}', '{agency.logo}', '{agency.startDate.ToString()}', {agency.notifyEveryone}, '{agency.lastChangedOn.ToString()}', '{agency.endDate.ToString()}', {agency.harvestTimersEnabled});";
                        var cmd = new SqlCommand(query, database.Conn);
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

        public TeamworkAgency Read(int id)
        {
            TeamworkAgency result = new TeamworkAgency();

            using (var database = this.GetConnection())
            {
                try
                {
                    string query = $"SELECT * FROM [ACE_Repository].[dbo].[TeamworkAgency] WHERE id = {id};";
                    var cmd = new SqlCommand(query, database.Conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.id = Convert.ToInt32(reader["id"]);
                        result.companyName = reader["companyName"].ToString();
                        result.companyId = Convert.ToInt32(reader["companyId"]);
                        result.starred = (bool)reader["starred"];
                        result.name = reader["name"].ToString();
                        result.showAnnouncement = (bool)reader["showAnnouncement"];
                        result.announcement = reader["announcement"].ToString();
                        result.description = reader["description"].ToString();
                        result.status = reader["status"].ToString();
                        result.createdOn = DateTime.Parse(reader["createdOn"].ToString());
                        result.categoryName = reader["categoryName"].ToString();
                        result.categoryId = Convert.ToInt32(reader["categoryId"]);
                        result.startPage = reader["startPage"].ToString();
                        result.logo = reader["logo"].ToString();
                        result.startDate = DateTime.Parse(reader["startDate"].ToString());
                        result.notifyEveryone = (bool)reader["notifyEveryone"];
                        result.lastChangedOn = DateTime.Parse(reader["lastChangedOn"].ToString());
                        result.endDate = DateTime.Parse(reader["endDate"].ToString());
                        result.harvestTimersEnabled = (bool)reader["harvestTimersEnabled"];
                        result.error = "";
                    }

                }
                catch (Exception ex)
                {
                    result.error = "Error: " + ex.Message;
                }
            }

            return result;
        }
    }
}