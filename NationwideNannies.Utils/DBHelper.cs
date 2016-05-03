using poliSYS.Common;
using poliSYS.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Utils
{
   public class DBHelper
    {
        public static DBInfo GetDbInfoFromConnectionString(string connectionStringName)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
            string dbServer = builder.DataSource;
            string dbInstance = builder.InitialCatalog;
            var user = builder.UserID;
            var password = builder.Password;

            DBInfo dbInfo = new DBInfo(dbServer, dbInstance, user, password);

            return dbInfo;
        }

        public static HelperFacade GetHelperFacade()
        {
            var dbInfo = DBHelper.GetDbInfoFromConnectionString("CMSTAT");
            HelperFacade hf = new HelperFacade();
            hf.DbInformation = dbInfo;

            return hf;
        }
    }
}
