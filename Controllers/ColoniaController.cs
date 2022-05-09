using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
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
            if (colonia.NomColonia == null || colonia.NomColonia.Length == 0 || colonia.idMunicipio <= 0)
            {
                ModelState.AddModelError("Colonia", "Datos incompletos");
                return BadRequest(ModelState);
               
            }
            
            Colonia.insertData(_configuration, colonia);

            return Ok();

        }

        [Route("api/colonia/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            if (id == 0 || id < 0 || id >= 15000)
            {
                ModelState.AddModelError("id", "valor inválido");
                return BadRequest(ModelState);
                
            }

            Colonia.delete(_configuration, id);

            return Ok();

        }

        [Route("api/colonia/{id:int}")]
        [HttpPut]
        public ActionResult Put(int id, Colonia colonia)
        {


            String query = @"Update dbo.Colonia ";
            if (id == 0 || id < 0 || id >= 15000)
            {
                ModelState.AddModelError("id", "valor inválido");
                return BadRequest(ModelState);
            }

            if (colonia.NomColonia != null)
            {
                query += @" set NomColonia = '" + colonia.NomColonia + @"'";

            }
            else
            {
                ModelState.AddModelError("NomColonia", "Valor requerido");
                return BadRequest(ModelState);
            }

            

            query += @"where IdColonia = " + id;

            Colonia.update(_configuration, query);

            return Ok();

        }
    }
}
