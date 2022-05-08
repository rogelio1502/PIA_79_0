using Microsoft.Extensions.Configuration;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PIA_79_0.Models
{
    public class Colonia
    {

        public string NomColonia { get; set; }
        public int idMunicipio { get; set; }


        public static DataTable getdata(IConfiguration _configuration)
        {
            string query = @"
                select * from dbo.Colonia
            ";

            BaseModel baseModel = new BaseModel(_configuration);

            DataTable table = baseModel.GetDataTable(query);

            return table;
        }

        public static void insertData(IConfiguration _configuration, Colonia colonia)
        {
            string query = @"
                insert into dbo.Colonia (NomColonia) values
                ('" + colonia.NomColonia + @"')
            ";

            BaseModel baseModel = new BaseModel(_configuration);

            baseModel.Insert(query);

        }

        public static void delete(IConfiguration _configuration, int id)
        {
            string query = @"delete from dbo.Colonia where IdColonia = " + id;
            BaseModel baseModel = new BaseModel(_configuration);
            baseModel.Delete(query);

        }

        public static void update(IConfiguration _configuration, string query)
        {
            BaseModel baseModel = new BaseModel(_configuration);
            baseModel.Update(query);
        }
    }
}
