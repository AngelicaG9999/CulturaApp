using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class InfoPersonaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<InfoPersonaBDO>> GetAll(long EmpresaID, long InscripcionID)
        {
            InfoPersonaBDO InfoPersonaBdo = new();
            InfoPersonaBLL InfoPersonaBll = new();

            InfoPersonaBdo.EmpresaID = EmpresaID;
            InfoPersonaBdo.InscripcionID = InscripcionID;

            return InfoPersonaBll.GetAll(InfoPersonaBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<InfoPersonaBDO> GetById(long InfoPersonaID)
        {
            InfoPersonaBLL InfoPersonaBll = new();
            InfoPersonaBDO InfoPersonaBdo = InfoPersonaBll.GetByID(InfoPersonaID);
            return InfoPersonaBdo;
        }

        [HttpPost("Add")]
        public ActionResult<InfoPersonaBDO> Add(InfoPersonaBDO InfoPersonaBdo)
        {
            InfoPersonaBLL InfoPersonaBll = new();
            InfoPersonaBdo.InfoPersonaID = InfoPersonaBll.Add(InfoPersonaBdo);
            return InfoPersonaBdo;
        }

        [HttpPut("Update")]
        public void Update(InfoPersonaBDO InfoPersonaBdo)
        {
            InfoPersonaBLL InfoPersonaBll = new InfoPersonaBLL();
            InfoPersonaBll.Update(InfoPersonaBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long InfoPersonaID)
        {
            InfoPersonaBLL InfoPersonaBll = new InfoPersonaBLL();
            InfoPersonaBll.Delete(InfoPersonaID);
        }

    }
}
