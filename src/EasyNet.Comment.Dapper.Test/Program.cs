using Dapper;
using EasyNet.Comment.Context;
using EasyNet.Comment.Dapper;
using EasyNet.Comment.Autofac;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using EasyNet.Comment.Ioc;

namespace EasyNet.Comment.Dapper.Test
{
    class Program
    {
        public static IDapper dapper;
        static void Main(string[] args)
        {
            IocContainerContext.Create().UserAutofac().UseDapper().BuildContainer();

            string connectString = "Data Source=101.200.33.140;Initial Catalog=bslm;Persist Security Info=True;User ID=bslm;Password=bslm123!@#;MultipleActiveResultSets=True;Integrated Security=false";
            IDbConnection connection = new SqlConnection(connectString);


            DynamicParameters dp = new DynamicParameters();
            dp.Add("masterType", "LV_SysMenus", DbType.String);

            //var items = SqlDapperExtensions.QuereyProcedure<LabelValue>(connection, dp, "usp_lv");


            dapper = IocContainerInvoker.Resolve<IDapper>();

            int count = dapper.GetCount(connection, null, "Sys_User");
            Console.WriteLine(count.ToString());
            Console.ReadKey();
            //foreach (var i in items)
            //{
            //    Console.WriteLine(i.ToString());
            //}
        }
    }
}
