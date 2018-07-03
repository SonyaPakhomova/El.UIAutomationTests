using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;
using NUnit.Framework;

namespace El.Test.UiTests.Modules
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            
            string fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            string con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;",TestContext.CurrentContext.TestDirectory+fileName);
            
            return con;
        }

        public static UserTab GetUserData(string keyName, string sheet)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from ["+sheet+"$] where key='{0}'", keyName);
                var value = connection.Query<UserTab>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
        public static InvestorTab GetInvestorData(string keyName, string sheet)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [" + sheet + "$] where key='{0}'", keyName);
                var value = connection.Query<InvestorTab>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
        public static LoginTab GetLoginData(string keyName, string sheet)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [" + sheet + "$] where key='{0}'", keyName);
                var value = connection.Query<LoginTab>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
        public static TabsTab GetTabData(string keyName, string sheet)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [" + sheet + "$] where key='{0}'", keyName);
                var value = connection.Query<TabsTab>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
        public static CreditProductTab GetCreditProductData(string keyName, string sheet)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [" + sheet + "$] where key='{0}'", keyName);
                var value = connection.Query<CreditProductTab>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
