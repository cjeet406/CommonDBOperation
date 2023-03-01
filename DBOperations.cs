//using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer.Logics
{
    public class DBOperations
    {
        private SqlConnection connection;
        //private SqlCommand Sqlcmd;
        //private SqlDataAdapter adapter;
        //private DataSet dataset;

        public string connectionString { get; set; }
        ConnectionString con;


        public string GenerateApi(string value)
        {
            string staticValue = "https://localhost:5001/api/test";
            string genratedApi;
            try
            {
                string dynamicValue = staticValue + $"/{value}";
                genratedApi = dynamicValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            return genratedApi;
        }

        public void OpenConnection()
        {
            //connectionString = con.GetConnectionString();
            //connection = new SqlConnection(connectionString);
            connectionString = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CloseConnection()
        {
            connectionString = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteStringQuery(string Query)
        {
            connectionString = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);

            OpenConnection();
            object obj = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;

            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }
            return obj;
        }

        public SqlDataReader fetchDataReader(string Query)
        {
            //connectionString = con.GetConnectionString();
            connectionString = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);

            OpenConnection();
            var cmd = new SqlCommand(Query, connection);
            SqlDataReader reader;
            try
            {
                //reader = cmd.ExecuteReader();
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                cmd.Dispose();
                CloseConnection();
                throw e;
            }
            return reader;
        }

        public object Sp_Execute(string spName, SqlCommand cmd)
        {
            connectionString = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            OpenConnection();
            cmd.Connection = connection;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            object obj;
            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                CloseConnection();
            }

            return obj;
        }

    }
}
