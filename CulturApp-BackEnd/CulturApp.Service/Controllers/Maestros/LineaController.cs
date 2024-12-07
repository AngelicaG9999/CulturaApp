using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("[controller]")]
    [ApiController]
    public class LineaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public ActionResult<List<LineaBDO>> GetAll(long EmpresaID, string Nombre, long AreaID, string Tipo)
        {
            LineaBDO LineaBdo = new();
            LineaBLL LineaBll = new();

            LineaBdo.EmpresaID = EmpresaID;
            LineaBdo.Nombre = Nombre;
            LineaBdo.AreaID = AreaID;
            LineaBdo.Tipo = Tipo;

            return LineaBll.GetAll(LineaBdo);
        }

        [HttpGet("GetById")]
        public ActionResult<LineaBDO> GetById(long LineaID)
        {
            LineaBLL LineaBll = new();
            LineaBDO LineaBdo = LineaBll.GetByID(LineaID);
            return LineaBdo;
        }

        [HttpPost("Add")]
        public ActionResult<LineaBDO> Add(LineaBDO LineaBdo)
        {
            LineaBLL LineaBll = new();
            LineaBdo.LineaID = LineaBll.Add(LineaBdo);
            return LineaBdo;
        }

        [HttpPut("Update")]
        public void Update(LineaBDO LineaBdo)
        {
            LineaBLL LineaBll = new LineaBLL();
            LineaBll.Update(LineaBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long LineaID)
        {
            LineaBLL LineaBll = new LineaBLL();
            LineaBll.Delete(LineaID);
        }

    }
}
