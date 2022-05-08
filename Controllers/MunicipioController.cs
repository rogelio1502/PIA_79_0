using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
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
            

            if(municipio.NomMunicipio == null || municipio.NomMunicipio.Length == 0)
            {
                ModelState.AddModelError("Municipio", "Datos incompletos");
                return BadRequest(ModelState);
            }

            Municipio.insertData(_configuration,municipio);

            return Ok();

        }

        [Route("api/municipio/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {


            if (id == 0 || id < 0 || id >= 15000)
            {
                ModelState.AddModelError("id", "valor inválido");
                return BadRequest(ModelState);
            }

            Municipio.delete(_configuration, id);

            return Ok();

        }


        [Route("api/municipio/{id:int}")]
        [HttpPut]
        public ActionResult Put(int id, Municipio municipio)
        {


            String query = @"Update dbo.Municipio ";
            if (id == 0 || id < 0)
            {
                ModelState.AddModelError("id", "valor inválido");
                return BadRequest(ModelState);
            }

            if(municipio.NomMunicipio != null)
            {
                query += @" set NomMunicipio = '" + municipio.NomMunicipio + @"'";
                
            }
            else
            {
                ModelState.AddModelError("NomMunicipio", "Valor requerido");
                return BadRequest(ModelState);
            }

            query += @"where IdMunicipio = " + id; 

            Municipio.update(_configuration, query);

            return Ok();

        }

    }
}
