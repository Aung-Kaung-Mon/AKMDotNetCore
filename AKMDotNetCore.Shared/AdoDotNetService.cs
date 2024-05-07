using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AKMDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json)!;

            return list;

        }

        public T? QueryFirstOrDefault<T>(string query , List<AdoDotNetParameter>? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            if(parameters is not null && parameters.Count > 0)
            {
                foreach(var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Name, param.Value);
                }
            }

            //command.Parameters.AddRange(parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray());

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return default(T);
                
            }

            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json)!;

            return list[0];
        

        }

        public int Execute(string query, List<AdoDotNetParameter>? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Count > 0)
            {
                foreach( var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Name , param.Value);
                }
            }
            var result = cmd.ExecuteNonQuery();

            return result;
        }


    }

    public class AdoDotNetParameter
    {
        public string Name;
        public object Value;

        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }


}
