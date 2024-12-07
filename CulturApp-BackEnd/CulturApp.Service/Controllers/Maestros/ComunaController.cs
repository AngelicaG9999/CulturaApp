using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<ComunaBDO>> GetAll(long EmpresaID, string Nombre)
        {
            ComunaBDO ComunaBdo = new();
            ComunaBLL ComunaBll = new();

            ComunaBdo.EmpresaID = EmpresaID;
            ComunaBdo.Nombre = Nombre;

            return ComunaBll.GetAll(ComunaBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<ComunaBDO> GetById(long ComunaID)
        {
            ComunaBLL ComunaBll = new();
            ComunaBDO ComunaBdo = ComunaBll.GetByID(ComunaID);
            return ComunaBdo;
        }

        [HttpPost("Add")]
        public ActionResult<ComunaBDO> Add(ComunaBDO ComunaBdo)
        {
            ComunaBLL ComunaBll = new();
            ComunaBdo.ComunaID = ComunaBll.Add(ComunaBdo);
            return ComunaBdo;
        }

        [HttpPut("Update")]
        public void Update(ComunaBDO ComunaBdo)
        {
            ComunaBLL ComunaBll = new ComunaBLL();
            ComunaBll.Update(ComunaBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long ComunaID)
        {
            ComunaBLL ComunaBll = new ComunaBLL();
            ComunaBll.Delete(ComunaID);
        }

    }
}

