using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using PIA_79_0.Models;

namespace PIA_79_0.Controllers
{
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MunicipioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/municipio")]
        [HttpGet]
        public JsonResult Get()
        {

            DataTable table = Municipio.getdata(_configuration);

            return new JsonResult(table);
        }

        [Route("api/municipio")]
        [HttpPost]
        public ActionResult Post(Municipio municipio)
        {
            

            if(municipio.NomMunicipio == null)
            {
                return BadRequest();
            }

            Municipio.insertData(_configuration,municipio);

            return Ok();

        }

        [Route("api/municipio/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {


            if (id == 0 || id < 0)
            {
                return BadRequest();
            }

            Municipio.delete(_configuration, id);

            return Ok();

        }

    }
}
