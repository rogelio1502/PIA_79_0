using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace PIA_79_0.Models
{
    public class BaseModel
    {
        private readonly IConfiguration _configuration;

        public BaseModel(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public DataTable do_query(String query)
        {
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBVETERINARIAAppConn");

            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return table;
        }

        public DataTable GetDataTable(String query)
        {
            DataTable table = do_query(query);
            return table;
        }

        public void Insert(String query)
        {
            do_query(query);
        }
        public void Delete(String query)
        {
            do_query(query);
        }

        public void Update(String query)
        {
            do_query(query);
        }
    }
}
