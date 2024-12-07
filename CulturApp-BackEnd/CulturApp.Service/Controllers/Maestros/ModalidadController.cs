using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class ModalidadController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<ModalidadBDO>> GetAll(long EmpresaID, string Nombre)
        {
            ModalidadBDO ModalidadBdo = new();
            ModalidadBLL ModalidadBll = new();

            ModalidadBdo.EmpresaID = EmpresaID;
            ModalidadBdo.Nombre = Nombre;

            return ModalidadBll.GetAll(ModalidadBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<ModalidadBDO> GetById(long ModalidadID)
        {
            ModalidadBLL ModalidadBll = new();
            ModalidadBDO ModalidadBdo = ModalidadBll.GetByID(ModalidadID);
            return ModalidadBdo;
        }

        [HttpPost("Add")]
        public ActionResult<ModalidadBDO> Add(ModalidadBDO ModalidadBdo)
        {
            ModalidadBLL ModalidadBll = new();
            ModalidadBdo.ModalidadID = ModalidadBll.Add(ModalidadBdo);
            return ModalidadBdo;
        }

        [HttpPut("Update")]
        public void Update(ModalidadBDO ModalidadBdo)
        {
            ModalidadBLL ModalidadBll = new ModalidadBLL();
            ModalidadBll.Update(ModalidadBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long ModalidadID)
        {
            ModalidadBLL ModalidadBll = new ModalidadBLL();
            ModalidadBll.Delete(ModalidadID);
        }

    }
}
