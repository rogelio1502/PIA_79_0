using Microsoft.Extensions.Configuration;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PIA_79_0.Models
{
    public class Proveedor 
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del Proveedor es requerido")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="El télefono es requerido")]
        [StringLength(10,MinimumLength =10,ErrorMessage = "El télefono debe tener 10 digitos")]
        public string Tel { get; set; }

        public int IdColonia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Calle y Número son requeridos")]
        public string CalleN { get; set; }

        public int CP { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="La fecha es requerida")]
        [DataType(DataType.Date,ErrorMessage = "Formato de Fecha Inválido")]
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
                '" + proveedor.IdColonia + @"',
                '" + proveedor.CalleN + @"',
                '" + proveedor.CP + @"',
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
        public static void update(IConfiguration _configuration, string query)
        {
            BaseModel baseModel = new BaseModel(_configuration);
            baseModel.Update(query);
        }
    }
}
