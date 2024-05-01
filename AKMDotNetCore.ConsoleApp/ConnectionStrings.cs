using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.ConsoleApp;

public static class ConnectionStrings
{
    public static SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "LAPTOP-HA19D87N",
        InitialCatalog = "AKMDotNetCore",
        UserID = "sa",
        Password = "sa@123"
    };
}
