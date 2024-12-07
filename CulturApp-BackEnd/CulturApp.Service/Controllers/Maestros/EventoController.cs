using CulturApp.BDO.GestionDatosMaestros;
using CulturApp.BLL.GestionDatosMaestros;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CulturApp.Service.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        [HttpGet("GetAll")]
        public IActionResult GetAll(long EmpresaID, long SalaID, string Nombre, string FechaHora)
        {
            try
            {
                EventoBLL EventoBll = new EventoBLL();
                var DataEvento = EventoBll.GetAll(EmpresaID, SalaID, Nombre, FechaHora);
                return Ok(JsonConvert.SerializeObject(DataEvento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpGet("GetById")]
        public ActionResult<EventoBDO> GetById(long EventoID)
        {
            EventoBLL EventoBll = new();
            EventoBDO EventoBdo = EventoBll.GetByID(EventoID);
            return EventoBdo;
        }

        [HttpPost("Add")]
        public ActionResult<EventoBDO> Add(EventoBDO EventoBdo)
        {
            EventoBLL EventoBll = new();
            EventoBdo.EventoID = EventoBll.Add(EventoBdo);
            return EventoBdo;
        }

        [HttpPut("Update")]
        public void Update(EventoBDO EventoBdo)
        {
            EventoBLL EventoBll = new EventoBLL();
            EventoBll.Update(EventoBdo);
        }

        [HttpDelete("Delete")]
        public void Delete(long EventoID)
        {
            EventoBLL EventoBll = new EventoBLL();
            EventoBll.Delete(EventoID);
        }

    }
}
