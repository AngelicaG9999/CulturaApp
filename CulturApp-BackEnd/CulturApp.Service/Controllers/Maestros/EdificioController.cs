using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdificioController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<EdificioBDO>> GetAll(long EmpresaID, long BarrioID, string Nombre)
        {
            EdificioBDO EdificioBdo = new();
            EdificioBLL EdificioBll = new();

            EdificioBdo.EmpresaID = EmpresaID;
            EdificioBdo.BarrioID = BarrioID;
            EdificioBdo.Nombre = Nombre;

            return EdificioBll.GetAll(EdificioBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<EdificioBDO> GetById(long EdificioID)
        {
            EdificioBLL EdificioBll = new();
            EdificioBDO EdificioBdo = EdificioBll.GetByID(EdificioID);
            return EdificioBdo;
        }

        [HttpPost("Add")]
        public ActionResult<EdificioBDO> Add(EdificioBDO EdificioBdo)
        {
            EdificioBLL EdificioBll = new();
            EdificioBdo.EdificioID = EdificioBll.Add(EdificioBdo);
            return EdificioBdo;
        }

        [HttpPut("Update")]
        public void Update(EdificioBDO EdificioBdo)
        {
            EdificioBLL EdificioBll = new EdificioBLL();
            EdificioBll.Update(EdificioBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long EdificioID)
        {
            EdificioBLL EdificioBll = new EdificioBLL();
            EdificioBll.Delete(EdificioID);
        }

    }
}
