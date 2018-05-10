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
                        string query = $"INSERT INTO [ACE_Repository].[dbo].[TeamworkAgency] (companyName, companyId, starred, name, showAnnouncement, announcement, description, status, createdOn, categoryName, categoryId, startPage, logo, startDate, notifyEveryone, lastChangedOn, endDate, harvestTimersEnabled) VALUES ('{agency.company.name}', {(agency.company.id.HasValue == true ? agency.company.id : 0)}, '{agency.starred.ToString()}', '{agency.name}', '{agency.showAnnouncement.ToString()}', '{agency.announcement}', '{agency.description}', '{agency.status}', '{agency.createdOn.ToString()}', '{agency.category.name}', {(agency.category.id.HasValue == true ? agency.category.id : 0)}, '{agency.startPage}', '{agency.logo}', '{agency.startDate.ToString()}', '{agency.notifyEveryone.ToString()}', '{agency.lastChangedOn.ToString()}', '{agency.endDate.ToString()}', '{agency.harvestTimersEnabled.ToString()}');";
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
                        result.company.name = reader["companyName"].ToString();
                        if (reader["companyId"] != null)
                        {
                            result.company.id = Convert.ToInt32(reader["companyId"]);
                        }
                        if (reader["starred"] != null)
                        {
                            result.starred = (bool)reader["starred"];
                        }
                        result.name = reader["name"].ToString();
                        if (reader["showAnnouncement"] != null)
                        {
                            result.showAnnouncement = (bool)reader["showAnnouncement"];
                        }
                        result.announcement = reader["announcement"].ToString();
                        result.description = reader["description"].ToString();
                        result.status = reader["status"].ToString();
                        if (reader["createdOn"] != null)
                        {
                            result.createdOn = DateTime.Parse(reader["createdOn"].ToString());
                        }
                        result.category.name = reader["categoryName"].ToString();
                        if (reader["categoryId"] != null)
                        {
                            result.category.id = Convert.ToInt32(reader["categoryId"]);
                        }
                        result.startPage = reader["startPage"].ToString();
                        result.logo = reader["logo"].ToString();
                        if (reader["startDate"] != null)
                        {
                            result.startDate = DateTime.Parse(reader["startDate"].ToString());
                        }
                        if (reader["notifyEveryone"] != null)
                        {
                            result.notifyEveryone = (bool)reader["notifyEveryone"];
                        }
                        if (reader["lastChangedOn"] != null)
                        {
                            result.lastChangedOn = DateTime.Parse(reader["lastChangedOn"].ToString());
                        }
                        if (reader["endDate"] != null)
                        {
                            result.endDate = DateTime.Parse(reader["endDate"].ToString());
                        }
                        if (reader["harvestTimersEnabled"] != null)
                        {
                            result.harvestTimersEnabled = (bool)reader["harvestTimersEnabled"];
                        }
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

        public List<TeamworkAgency> ReadAll()
        {
            List<TeamworkAgency> result = new List<TeamworkAgency>();

            using (var database = this.GetConnection())
            {
                try
                {
                    string query = $"SELECT * FROM [ACE_Repository].[dbo].[TeamworkAgency];";
                    var cmd = new SqlCommand(query, database.Conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var newAgency = new TeamworkAgency();

                        newAgency.id = Convert.ToInt32(reader["id"]);
                        newAgency.company.name = reader["companyName"].ToString();
                        if (newAgency.company.id.HasValue)
                        {
                            newAgency.company.id = Convert.ToInt32(reader["companyId"]);
                        }
                        if (newAgency.starred.HasValue)
                        {
                            newAgency.starred = (bool)reader["starred"];
                        }
                        newAgency.name = reader["name"].ToString();
                        if (newAgency.showAnnouncement.HasValue)
                        {
                            newAgency.showAnnouncement = (bool)reader["showAnnouncement"];
                        }
                        newAgency.announcement = reader["announcement"].ToString();
                        newAgency.description = reader["description"].ToString();
                        newAgency.status = reader["status"].ToString();
                        if (newAgency.createdOn.HasValue)
                        {
                            newAgency.createdOn = DateTime.Parse(reader["createdOn"].ToString());
                        }
                        newAgency.category.name = reader["categoryName"].ToString();
                        if (newAgency.category.id.HasValue)
                        {
                            newAgency.category.id = Convert.ToInt32(reader["categoryId"]);
                        }
                        newAgency.startPage = reader["startPage"].ToString();
                        newAgency.logo = reader["logo"].ToString();
                        if (newAgency.startDate.HasValue)
                        {
                            newAgency.startDate = DateTime.Parse(reader["startDate"].ToString());
                        }
                        if (newAgency.notifyEveryone.HasValue)
                        {
                            newAgency.notifyEveryone = (bool)reader["notifyEveryone"];
                        }
                        if (newAgency.lastChangedOn.HasValue)
                        {
                            newAgency.lastChangedOn = DateTime.Parse(reader["lastChangedOn"].ToString());
                        }
                        if (newAgency.endDate.HasValue)
                        {
                            newAgency.endDate = DateTime.Parse(reader["endDate"].ToString());
                        }
                        if (newAgency.harvestTimersEnabled.HasValue)
                        {
                            newAgency.harvestTimersEnabled = (bool)reader["harvestTimersEnabled"];
                        }
                        newAgency.error = "";

                        result.Add(new TeamworkAgency(newAgency));
                    }

                }
                catch (Exception ex)
                {
                    result.Add(new TeamworkAgency());
                    result[0].error = "Error: " + ex.Message;
                }
            }

            return result;
        }

        public string Delete(int id)
        {
            string result = "";

            using (var database = this.GetConnection())
            {
                using (var transaction = database.Conn.BeginTransaction())
                {
                    try
                    {
                        string query = $"DELETE FROM [ACE_Repository].[dbo].[TeamworkAgency] WHERE id = {id};";
                        var cmd = new SqlCommand(query, database.Conn, transaction);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows != 1)
                        {
                            throw new Exception("Incorrect number of rows deleted! Expected 1, deleted " + rows);
                        }
                        else
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