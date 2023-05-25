using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Datos;
using Microsoft.AspNetCore.JsonPatch;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        //List<Villa> _lstVilla = new List<Villa>();

        //
        private readonly ILogger<VillaController> _logger;

        //Metodo para inyectar servico de Logger
        public VillaController(ILogger<VillaController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<VillaDto>> cargarVilla()
        {
            _logger.LogInformation("Consultar todas las Villas");//Mensaje Informativo
            //OK: estado de codigo vacio
            return Ok(VillaStore._lstVilla);
        }

        [HttpGet("id", Name = "GetVilla")]        
        [ProducesResponseType(StatusCodes.Status200OK)] //Atributos de codigo de estado
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            //Validacion de existencia(id ingresado)
            if(id == 0)
            {
                _logger.LogError($"Error al consultar Villa con ID: {id}");
                return BadRequest();
            }
                var villa = VillaStore._lstVilla.FirstOrDefault(x => x.Id == id);

            if (id == null)
            {
                return NotFound();
            }

                return Ok(villa);            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<VillaDto> createVilla([FromBody] VillaDto villa) //FromBody para indicar que se recibiran datos
        {
            //Validacion ModelState
            if (!ModelState.IsValid) //Corroborar que se cumplan las validaciones o retornar BadRequest
            {
                return BadRequest(ModelState);
            }

            //Evitar que el nombre se repita una o dos veces
            if (VillaStore._lstVilla.FirstOrDefault(x=>x.Nombre.ToLower() == villa.Nombre.ToLower()) != null)
            {
                //Validacion personalizada
                ModelState.AddModelError("NombreExistente",$"La villa con el nombre '{villa.Nombre}' que intenta insertar ya existe");//Nombre de la validacion/Mensaje de la validacion
                return BadRequest(ModelState);
            }

            if (villa == null)
            {
                return BadRequest(villa);
            }

            if(villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villa.Id = VillaStore._lstVilla.OrderByDescending(x=>x.Id).FirstOrDefault().Id+1;
            VillaStore._lstVilla.Add(villa);

            //Indicar la URL del recuso creado
            return CreatedAtRoute("GetVilla", new {id = villa.Id}, villa);//retornar el metodo GetVilla recibe el id y manda el modelo

        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult deleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            
            var villa = VillaStore._lstVilla.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            VillaStore._lstVilla.Remove(villa);


            return NoContent();//En metodo DELETE siempre retornar NoContent

        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }

            var villa = VillaStore._lstVilla.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            villa.Nombre = villaDto.Nombre;
            villa.Ocupantes = villaDto.Ocupantes;
            villa.MetrosCuadrados = villaDto.MetrosCuadrados;

            return NoContent();
        }

        [HttpPatch("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult updatePatchVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();    

            }

            var villa = VillaStore._lstVilla.FirstOrDefault(x => x.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(villa, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
