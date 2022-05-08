using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using PIA_79_0.Models;


namespace PIA_79_0.Controllers
{
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProveedorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/proveedor")]
        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = Proveedor.getdata(this._configuration);

            return new JsonResult(table);
        }

        [Route("api/proveedor")]
        [HttpPost]
        public ActionResult Post(Proveedor proveedor)
        {

            if (
                (proveedor.Nombre == null || proveedor.Nombre.Length == 0) || 
                proveedor.IdColonia <= 0 || 
                (proveedor.CalleN == null || proveedor.CalleN.Length == 0 ) || 
                (proveedor.Tel == null || proveedor.Tel.Length != 10) || 
                (proveedor.CP <= 0)
            )
            {
                ModelState.AddModelError("Proveedor", "Datos incompletos.");
                return BadRequest(ModelState);
            }
            try
            {
                DateTime.Parse(proveedor.FecRegistro);
            }catch (Exception e)
            {
                ModelState.AddModelError("Fecha Registro", "Fecha Inválida.");
                return BadRequest(ModelState);
            }
            Proveedor.insertData(_configuration, proveedor);

            return Ok();

        }

        [Route("api/proveedor/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {


            if (id == 0 || id < 0 || id >= 15000)
            {
                ModelState.AddModelError("id", "Valor inválido");
                return BadRequest(ModelState);
            }

            Proveedor.delete(_configuration, id);

            return Ok();

        }

        [Route("api/proveedor/{id:int}")]
        [HttpPut]
        public ActionResult Put(int id, Proveedor proveedor)
        {


            String query = @"Update dbo.Proveedor ";
            if (id == 0 || id < 0 || id >= 15000)
            {
                ModelState.AddModelError("id", "valor inválido");
                return BadRequest(ModelState);
            }

            if (proveedor.Nombre != null)
            {
                query += @" set Nombre = '" + proveedor.Nombre + @"'";

            }
            else
            {
                ModelState.AddModelError("Nombre", "Valor requerido");
                return BadRequest(ModelState);
            }

            if (proveedor.CalleN != null)
            {
                query += @" set CalleN = '" + proveedor.CalleN + @"'";

            }
            else
            {
                ModelState.AddModelError("CalleN", "Valor requerido");
                return BadRequest(ModelState);
            }

            if (proveedor.CP <= 0)
            {
                query += @" set CP = '" + proveedor.CP + @"'";

            }
            else
            {
                ModelState.AddModelError("CP", "Valor requerido");
                return BadRequest(ModelState);
            }

            if (proveedor.FecRegistro  != null)
            {
                try
                {
                    DateTime.Parse(proveedor.FecRegistro);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Fecha Registro", "Fecha Inválida.");
                    return BadRequest(ModelState);
                }
                query += @" set FecRegistro = '" + proveedor.FecRegistro + @"'";

            }
            else
            {
                ModelState.AddModelError("FecRegistro", "Valor requerido");
                return BadRequest(ModelState);
            }

            if (proveedor.Tel != null && proveedor.Tel.Length == 10)
            {
                query += @" set Tel = '" + proveedor.Tel + @"'";

            }
            else
            {
                ModelState.AddModelError("Tel", "Valor requerido");
                return BadRequest(ModelState);
            }

            query += @"where IdProveedor = " + id;

            Proveedor.update(_configuration, query);

            return Ok();

        }
    }
}
