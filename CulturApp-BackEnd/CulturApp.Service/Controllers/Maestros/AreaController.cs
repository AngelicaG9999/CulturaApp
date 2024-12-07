using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<AreaBDO>> GetAll(long EmpresaID, string Nombre, long ModalidadID)
        {
            AreaBDO AreaBdo = new();
            AreaBLL AreaBll = new();

            AreaBdo.EmpresaID = EmpresaID;
            AreaBdo.ModalidadID = ModalidadID;
            AreaBdo.Nombre = Nombre;

            return AreaBll.GetAll(AreaBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<AreaBDO> GetById(long AreaID)
        {
            AreaBLL AreaBll = new();
            AreaBDO AreaBdo = AreaBll.GetByID(AreaID);
            return AreaBdo;
        }

        [HttpPost("Add")]
        public ActionResult<AreaBDO> Add(AreaBDO AreaBdo)
        {
            AreaBLL AreaBll = new();
            AreaBdo.AreaID = AreaBll.Add(AreaBdo);
            return AreaBdo;
        }

        [HttpPut("Update")]
        public void Update(AreaBDO AreaBdo)
        {
            AreaBLL AreaBll = new AreaBLL();
            AreaBll.Update(AreaBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long AreaID)
        {
            AreaBLL AreaBll = new AreaBLL();
            AreaBll.Delete(AreaID);
        }

    }
}
