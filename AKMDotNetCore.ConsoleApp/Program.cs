// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
Console.WriteLine("");
//Console.ReadKey();

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = "LAPTOP-HA19D87N";
connectionStringBuilder.InitialCatalog = "AKMDotNetCore";
connectionStringBuilder.UserID = "sa";
connectionStringBuilder.Password = "sa@123";

SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
connection.Open();

string query = "select * from dbo.Tbl_Blogs";
SqlCommand command = new SqlCommand(query, connection);
//
SqlDataAdapter adapter = new SqlDataAdapter(command);
DataTable dataTable = new DataTable();
adapter.Fill(dataTable);

connection.Close();

foreach (DataRow row in dataTable.Rows)
{
    Console.WriteLine("BlogId => " + row["BlogID"]);
    Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
    Console.WriteLine("BlogArthur => " + row["BlogArthur"]);
    Console.WriteLine("BlogContent => " + row["BlogContent"]);
    Console.WriteLine("___________________________");
    Console.WriteLine("");
}