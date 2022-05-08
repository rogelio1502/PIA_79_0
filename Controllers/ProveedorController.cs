using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
                return BadRequest();
            }

            Proveedor.insertData(_configuration, proveedor);

            return Ok();

        }

        [Route("api/proveedor/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {


            if (id == 0 || id < 0)
            {
                return BadRequest();
            }

            Proveedor.delete(_configuration, id);

            return Ok();

        }
    }
}
