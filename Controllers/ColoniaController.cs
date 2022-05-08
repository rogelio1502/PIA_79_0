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
    public class ColoniaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ColoniaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/colonia")]
        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = Colonia.getdata(_configuration);

            return new JsonResult(table);
        }

        [Route("api/colonia")]
        [HttpPost]
        public ActionResult Post(Colonia colonia)
        {
            if(colonia.NomColonia == null || colonia.NomColonia.Length < 1)
            {
                return BadRequest();
            }
            
            Colonia.insertData(_configuration, colonia);

            return Ok();

            //return new JsonResult("Added");
        }

        [Route("api/colonia/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {


            if (id == 0 || id < 0)
            {
                return BadRequest();
            }

            Colonia.delete(_configuration, id);

            return Ok();

        }
    }
}
