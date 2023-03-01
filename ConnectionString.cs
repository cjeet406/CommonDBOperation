using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ConnectionString
    {
        protected IConfiguration conf { get; set; }
        public ConnectionString(IConfiguration conf)
        {
            this.conf = conf;
            //conf1 = this.conf;
        }
        

        public string GetConnectionString()
        {
            //var abc = conf["ConnectionStrings:default"];
            var abc = "Data Source=192.168.100.153;User ID=jeet;Password=jeet@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return abc;
        }
        
    }
}
