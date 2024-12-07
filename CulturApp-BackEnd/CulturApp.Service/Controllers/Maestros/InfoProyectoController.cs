using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class InfoProyectoController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<InfoProyectoBDO>> GetAll(long EmpresaID, long InscripcionID)
        {
            InfoProyectoBDO InfoProyectoBdo = new();
            InfoProyectoBLL InfoProyectoBll = new();

            InfoProyectoBdo.EmpresaID = EmpresaID;
            InfoProyectoBdo.InscripcionID = InscripcionID;

            return InfoProyectoBll.GetAll(InfoProyectoBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<InfoProyectoBDO> GetById(long InfoProyectoID)
        {
            InfoProyectoBLL InfoProyectoBll = new();
            InfoProyectoBDO InfoProyectoBdo = InfoProyectoBll.GetByID(InfoProyectoID);
            return InfoProyectoBdo;
        }

        [HttpPost("Add")]
        public ActionResult<InfoProyectoBDO> Add(InfoProyectoBDO InfoProyectoBdo)
        {
            InfoProyectoBLL InfoProyectoBll = new();
            InfoProyectoBdo.InfoProyectoID = InfoProyectoBll.Add(InfoProyectoBdo);
            return InfoProyectoBdo;
        }

        [HttpPut("Update")]
        public void Update(InfoProyectoBDO InfoProyectoBdo)
        {
            InfoProyectoBLL InfoProyectoBll = new InfoProyectoBLL();
            InfoProyectoBll.Update(InfoProyectoBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long InfoProyectoID)
        {
            InfoProyectoBLL InfoProyectoBll = new InfoProyectoBLL();
            InfoProyectoBll.Delete(InfoProyectoID);
        }

    }
}
