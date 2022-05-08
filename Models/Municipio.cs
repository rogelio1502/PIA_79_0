using Microsoft.Extensions.Configuration;
using System.Data;
namespace PIA_79_0.Models
{
    public class Municipio
    {

        public string NomMunicipio { get; set; }

        public static DataTable getdata(IConfiguration _configuration)
        {
            string query = @"
                select * from dbo.Municipio
            ";

            BaseModel baseModel = new BaseModel(_configuration);

            DataTable table = baseModel.GetDataTable(query);

            return table;
        }

        public static void insertData(IConfiguration _configuration, Municipio municipio)
        {
            string query = @"
                insert into dbo.Municipio (NomMunicipio) values
                ('" + municipio.NomMunicipio  + @"')
            ";
            
            BaseModel baseModel = new BaseModel(_configuration);

            baseModel.Insert(query);

        }

        public static void delete(IConfiguration _configuration, int id)
        {
            string query = @"delete from dbo.Municipio where IdMunicipio = " + id;
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
