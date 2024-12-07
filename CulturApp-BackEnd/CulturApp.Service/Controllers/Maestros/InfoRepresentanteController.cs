using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class InfoRepresentanteController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<InfoRepresentanteBDO>> GetAll(long EmpresaID, long InscripcionID)
        {
            InfoRepresentanteBDO InfoRepresentanteBdo = new();
            InfoRepresentanteBLL InfoRepresentanteBll = new();

            InfoRepresentanteBdo.EmpresaID = EmpresaID;
            InfoRepresentanteBdo.InscripcionID = InscripcionID;

            return InfoRepresentanteBll.GetAll(InfoRepresentanteBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<InfoRepresentanteBDO> GetById(long InfoRepresentanteID)
        {
            InfoRepresentanteBLL InfoRepresentanteBll = new();
            InfoRepresentanteBDO InfoRepresentanteBdo = InfoRepresentanteBll.GetByID(InfoRepresentanteID);
            return InfoRepresentanteBdo;
        }

        [HttpPost("Add")]
        public ActionResult<InfoRepresentanteBDO> Add(InfoRepresentanteBDO InfoRepresentanteBdo)
        {
            InfoRepresentanteBLL InfoRepresentanteBll = new();
            InfoRepresentanteBdo.InfoRepresentanteID = InfoRepresentanteBll.Add(InfoRepresentanteBdo);
            return InfoRepresentanteBdo;
        }

        [HttpPut("Update")]
        public void Update(InfoRepresentanteBDO InfoRepresentanteBdo)
        {
            InfoRepresentanteBLL InfoRepresentanteBll = new InfoRepresentanteBLL();
            InfoRepresentanteBll.Update(InfoRepresentanteBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long InfoRepresentanteID)
        {
            InfoRepresentanteBLL InfoRepresentanteBll = new InfoRepresentanteBLL();
            InfoRepresentanteBll.Delete(InfoRepresentanteID);
        }

    }
}
