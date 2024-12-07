using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<InscripcionBDO>> GetAll(long EmpresaID, long EstimuloID, string Radicado, long TipoID)
        {
            InscripcionBDO InscripcionBdo = new();
            InscripcionBLL InscripcionBll = new();

            InscripcionBdo.EmpresaID = EmpresaID;
            InscripcionBdo.EstimuloID = EstimuloID;
            InscripcionBdo.Radicado = Radicado;
            InscripcionBdo.TipoID = TipoID;

            return InscripcionBll.GetAll(InscripcionBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<InscripcionBDO> GetById(long InscripcionID)
        {
            InscripcionBLL InscripcionBll = new();
            InscripcionBDO InscripcionBdo = InscripcionBll.GetByID(InscripcionID);
            return InscripcionBdo;
        }

        [HttpPost("Add")]
        public ActionResult<InscripcionBDO> Add(InscripcionBDO InscripcionBdo)
        {
            InscripcionBLL InscripcionBll = new();
            InscripcionBdo.InscripcionID = InscripcionBll.Add(InscripcionBdo);
            return InscripcionBdo;
        }

        [HttpPut("Update")]
        public void Update(InscripcionBDO InscripcionBdo)
        {
            InscripcionBLL InscripcionBll = new InscripcionBLL();
            InscripcionBll.Update(InscripcionBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long InscripcionID)
        {
            InscripcionBLL InscripcionBll = new InscripcionBLL();
            InscripcionBll.Delete(InscripcionID);
        }

    }
}
