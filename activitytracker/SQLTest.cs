using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace activitytracker
{
    public class SQLTest
    {


        private static string connstring = "Server=ec2-54-225-227-125.compute-1.amazonaws.com;Port=5432;" +
                "User Id=gmfspcugewxtdy;Password=0a3fa49246619b219f330010a874a68db608c015e2c3b14e29e761423a226a8c;Database=dbjbhnajpvo2q4;SslMode=Require;";

        public DataTable testDatabase()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
        // PostgeSQL-style connection string

        // Making connection with Npgsql provider
        NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.UserCertificateValidationCallback = delegate { return true; };
            conn.Open();
            // quite complex sql statement
            string sql = "SELECT * FROM activities.test";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];
            var dtItem1 = dt.Rows[0].ItemArray[0];
            var dtItem2 = dt.Rows[0].ItemArray[1];
            var dtItem3 = dt.Rows[1].ItemArray[0];
            var dtItem4 = dt.Rows[1].ItemArray[1];
            Console.WriteLine("Here's the database output!!!");
            Console.WriteLine(dtItem1);
            Console.WriteLine(dtItem2);
            Console.WriteLine(dtItem3);
            Console.WriteLine(dtItem4);  // ** HOW TO GET THIS TO ABOUT PAGE ** //
            Console.WriteLine(dt);
            // since we only showing the result we don't need connection anymore
            conn.Close();

            return dt;

        }

        public void saveData(string activity, string location)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.UserCertificateValidationCallback = delegate { return true; };
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO activities.test (activity, location) VALUES (@activity, @location)", conn))
            {
                cmd.Parameters.AddWithValue("activity", activity);
                cmd.Parameters.AddWithValue("location", location);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        // TODO: change this so you don't need a duplicate method 
        public void saveTimeTracker(string activitytype, string activityname, int currenttime, int totaltime)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.UserCertificateValidationCallback = delegate { return true; };
            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO timetracker.activities (activitytype, activityname, currenttime, totaltime) VALUES (@activitytype, @activityname, @currenttime, @totaltime)", conn))
            {
                cmd.Parameters.AddWithValue("activitytype", activitytype);
                cmd.Parameters.AddWithValue("activityname", activityname);
                cmd.Parameters.AddWithValue("currenttime", currenttime);
                cmd.Parameters.AddWithValue("totaltime", totaltime);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        /*
        public void editData(string activity, string location)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.UserCertificateValidationCallback = delegate { return true; };
            conn.Open();

            using (var cmd = new NpgsqlCommand("UPDATE activities.test SET (activity, location) VALUES (@activity, @location)", conn))
            {
                cmd.Parameters.AddWithValue("activity", activity);
                cmd.Parameters.AddWithValue("location", location);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        } */
    }
}
