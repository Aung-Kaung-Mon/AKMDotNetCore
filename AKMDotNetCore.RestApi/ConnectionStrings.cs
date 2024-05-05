using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.RestApi;

public static class ConnectionStrings
{
    public static SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "LAPTOP-HA19D87N",
        InitialCatalog = "AKMDotNetCore",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true

    };
}
//Scaffold-DbContext "Server=LAPTOP-HA19D87N;Database=AKMDotNetCore;User ID=sa;Password=sa@123;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AKMDotNetCoreContext