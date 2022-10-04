using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.MySql;
using LinqToDB.DataProvider.SqlServer;
using Models;

namespace Connection
{
    public class Connections : DataConnection
    {
        //SQLServer
        public Connections() : base(new SqlServerDataProvider("", SqlServerVersion.v2012),
            "Data Source=localhost;Database=Sales_system;Persist Security Info=True;User ID=SA;Password=cega1234;MultipleActiveResultSets=True;application name=EntityFramework")
        {

        }


        ////MySQL
        //public Connections() : base(new MySqlDataProvider(),
        //"Data Source=localhost;Initial Catalog=Sales_system;Persist Security Info=True;User ID=SA;Password=cega1234;MultipleActiveResultSets=True;application name=EntityFramework")
        //{

        //}

        public ITable<TUsers> TUsers => GetTable<TUsers>();
    }
}
