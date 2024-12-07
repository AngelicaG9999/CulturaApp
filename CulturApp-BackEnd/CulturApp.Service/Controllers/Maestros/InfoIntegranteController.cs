using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class InfoIntegranteController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<InfoIntegranteBDO>> GetAll(long EmpresaID, string Nombre, long InscripcionID)
        {
            InfoIntegranteBDO InfoIntegranteBdo = new();
            InfoIntegranteBLL InfoIntegranteBll = new();

            InfoIntegranteBdo.EmpresaID = EmpresaID;
            InfoIntegranteBdo.InscripcionID = InscripcionID;

            return InfoIntegranteBll.GetAll(InfoIntegranteBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<InfoIntegranteBDO> GetById(long InfoIntegranteID)
        {
            InfoIntegranteBLL InfoIntegranteBll = new();
            InfoIntegranteBDO InfoIntegranteBdo = InfoIntegranteBll.GetByID(InfoIntegranteID);
            return InfoIntegranteBdo;
        }

        [HttpPost("Add")]
        public ActionResult<InfoIntegranteBDO> Add(InfoIntegranteBDO InfoIntegranteBdo)
        {
            InfoIntegranteBLL InfoIntegranteBll = new();
            InfoIntegranteBdo.InfoIntegranteID = InfoIntegranteBll.Add(InfoIntegranteBdo);
            return InfoIntegranteBdo;
        }

        [HttpPut("Update")]
        public void Update(InfoIntegranteBDO InfoIntegranteBdo)
        {
            InfoIntegranteBLL InfoIntegranteBll = new InfoIntegranteBLL();
            InfoIntegranteBll.Update(InfoIntegranteBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long InfoIntegranteID)
        {
            InfoIntegranteBLL InfoIntegranteBll = new InfoIntegranteBLL();
            InfoIntegranteBll.Delete(InfoIntegranteID);
        }

    }
}
