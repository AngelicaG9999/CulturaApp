using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<TipoBDO>> GetAll(long EmpresaID, string Nombre)
        {
            TipoBDO TipoBdo = new();
            TipoBLL TipoBll = new();

            TipoBdo.EmpresaID = EmpresaID;
            TipoBdo.Nombre = Nombre;

            return TipoBll.GetAll(TipoBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<TipoBDO> GetById(long TipoID)
        {
            TipoBLL TipoBll = new();
            TipoBDO TipoBdo = TipoBll.GetByID(TipoID);
            return TipoBdo;
        }

        [HttpPost("Add")]
        public ActionResult<TipoBDO> Add(TipoBDO TipoBdo)
        {
            TipoBLL TipoBll = new();
            TipoBdo.TipoID = TipoBll.Add(TipoBdo);
            return TipoBdo;
        }

        [HttpPut("Update")]
        public void Update(TipoBDO TipoBdo)
        {
            TipoBLL TipoBll = new TipoBLL();
            TipoBll.Update(TipoBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long TipoID)
        {
            TipoBLL TipoBll = new TipoBLL();
            TipoBll.Delete(TipoID);
        }

    }
}
