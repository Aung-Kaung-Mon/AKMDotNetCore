using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.ConsoleApp
{
    internal class AkmDotNetCore
    {

        private readonly SqlConnectionStringBuilder _connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP-HA19D87N",
            InitialCatalog = "AKMDotNetCore",
            UserID = "sa",
            Password = "sa@123"
        };
   
        public void Retrieve()
        {
       
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
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
                Console.WriteLine("____________________________");
                Console.WriteLine("");
            }
        }

        public void Create(string title , string author , string content)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            /*   string query = @$"INSERT INTO [dbo].[Tbl_Blogs]
              ([BlogTitle]
              ,[BlogArthur]
              ,[BlogContent])
        VALUES
              ('{title}' , '{author}','{content}') "; */

            string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogArthur]
           ,[BlogContent])
        VALUES
           (@BlogTitle, @BlogAuthor, @BlogContent)";


            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);

            int result = command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Created successfully" : "creation failed");

        } 

        public void Update(int id , string title , string author , string content)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blogs]
    SET [BlogTitle] = @BlogTitle
      ,[BlogArthur] = @BlogAuthor
      ,[BlogContent] = @BlogContent
    WHERE BlogID = @BlogID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle", title);
            command.Parameters.AddWithValue("@BlogAuthor", author);
            command.Parameters.AddWithValue("@BlogContent", content);
            command.Parameters.AddWithValue("@BlogID", id);
            
            int result = command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "Updated successfully" : "Failed update");
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Blogs]
                         WHERE BlogID = @BlogID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogID" , id);
            int result = command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result > 0 ? "successfully deleted" : "some error occurred");
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open(); 

            string query = "Select * from dbo.Tbl_Blogs Where BlogID = @BlogID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogID", id);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow row = dt.Rows[0];

            Console.WriteLine("BlogId => " + row["BlogID"]);
            Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
            Console.WriteLine("BlogArthur => " + row["BlogArthur"]);
            Console.WriteLine("BlogContent => " + row["BlogContent"]);


        }


    }
}
