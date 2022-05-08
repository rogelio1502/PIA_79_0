using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PIA_79_0.Models
{
    public class Proveedor 
    {
        public string Nombre { get; set; }
        public string Tel { get; set; }
        public int IdColonia { get; set; }
        public string CalleN { get; set; }
        public int CP { get; set; }
        public string FecRegistro { get; set; }



        public static DataTable getdata(IConfiguration _configuration)
        {
            string query = @"
                select * from dbo.Proveedor
            ";

            BaseModel baseModel = new BaseModel(_configuration);

            DataTable table = baseModel.GetDataTable(query);

            return table;
        }

        public static void insertData(IConfiguration _configuration, Proveedor proveedor)
        {
            string query = @"
                insert into dbo.Proveedor (Nombre, Tel, IdColonia, CalleN, CP, FecRegistro) values
                ('" + proveedor.Nombre + @"', 
                '"+ proveedor.Tel +@"', 
                '" + proveedor.IdColonia + @"')
                '" + proveedor.CalleN + @"')
                '" + proveedor.CP + @"')
                '" + proveedor.FecRegistro + @"')
            ";

            BaseModel baseModel = new BaseModel(_configuration);

            baseModel.Insert(query);

        }

        public static void delete(IConfiguration _configuration, int id)
        {
            string query = @"delete from dbo.Proveedor where IdProveedor = " + id;
            BaseModel baseModel = new BaseModel(_configuration);
            baseModel.Delete(query);

        }
    }
}
