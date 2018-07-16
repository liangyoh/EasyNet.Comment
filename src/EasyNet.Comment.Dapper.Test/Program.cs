using Dapper;
using EasyNet.Comment.Dapper;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EasyNet.Comment.Dapper.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = "Data Source=101.200.33.140;Initial Catalog=bslm;Persist Security Info=True;User ID=bslm;Password=bslm123!@#;MultipleActiveResultSets=True;Integrated Security=false";
            IDbConnection connection = new SqlConnection(connectString);


            DynamicParameters dp = new DynamicParameters();
            dp.Add("masterType", "LV_SysMenus", DbType.String);

            //var items = SqlDapperExtensions.QuereyProcedure<LabelValue>(connection, dp, "usp_lv");
            int count = SqlDapperExtensions.GetCount(connection, null, "Sys_User");
            Console.WriteLine(count.ToString());
            //foreach (var i in items)
            //{
            //    Console.WriteLine(i.ToString());
            //}
        }
    }
}
