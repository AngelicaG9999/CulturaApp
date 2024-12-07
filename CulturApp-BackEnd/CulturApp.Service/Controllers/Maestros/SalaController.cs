using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<SalaBDO>> GetAll(long EmpresaID, long EdificioID, string Nombre)
        {
            SalaBDO SalaBdo = new();
            SalaBLL SalaBll = new();

            SalaBdo.EmpresaID = EmpresaID;
            SalaBdo.EdificioID = EdificioID;
            SalaBdo.Nombre = Nombre;

            return SalaBll.GetAll(SalaBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<SalaBDO> GetById(long SalaID)
        {
            SalaBLL SalaBll = new();
            SalaBDO SalaBdo = SalaBll.GetByID(SalaID);
            return SalaBdo;
        }

        [HttpPost("Add")]
        public ActionResult<SalaBDO> Add(SalaBDO SalaBdo)
        {
            SalaBLL SalaBll = new();
            SalaBdo.SalaID = SalaBll.Add(SalaBdo);
            return SalaBdo;
        }

        [HttpPut("Update")]
        public void Update(SalaBDO SalaBdo)
        {
            SalaBLL SalaBll = new SalaBLL();
            SalaBll.Update(SalaBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long SalaID)
        {
            SalaBLL SalaBll = new SalaBLL();
            SalaBll.Delete(SalaID);
        }

    }
}
