using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarrioController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<BarrioBDO>> GetAll(long EmpresaID, long ComunaID,string Nombre)
        {
            BarrioBDO BarrioBdo = new();
            BarrioBLL BarrioBll = new();

            BarrioBdo.EmpresaID = EmpresaID;
            BarrioBdo.ComunaID = ComunaID;
            BarrioBdo.Nombre = Nombre;

            return BarrioBll.GetAll(BarrioBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<BarrioBDO> GetById(long BarrioID)
        {
            BarrioBLL BarrioBll = new();
            BarrioBDO BarrioBdo = BarrioBll.GetByID(BarrioID);
            return BarrioBdo;
        }

        [HttpPost("Add")]
        public ActionResult<BarrioBDO> Add(BarrioBDO BarrioBdo)
        {
            BarrioBLL BarrioBll = new();
            BarrioBdo.BarrioID = BarrioBll.Add(BarrioBdo);
            return BarrioBdo;
        }

        [HttpPut("Update")]
        public void Update(BarrioBDO BarrioBdo)
        {
            BarrioBLL BarrioBll = new BarrioBLL();
            BarrioBll.Update(BarrioBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long BarrioID)
        {
            BarrioBLL BarrioBll = new BarrioBLL();
            BarrioBll.Delete(BarrioID);
        }
    }
}
