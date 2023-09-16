using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_Vehiculo.DTO.VehiculoDTO;
using Practica_Vehiculo.Entities;
using Practica_Vehiculo.Services;

namespace Practica_Vehiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehiculoController : ControllerBase

    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;

        public VehiculoController(IVehiculoService vehiculoService, IMapper mapper)
        {
            _vehiculoService = vehiculoService;
            _mapper = mapper;
        } 

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get( ) 
        {
            return Ok("HTTP GET");
        }

        [HttpPost]
        public async Task<ActionResult> Post(VehiculoCreateDTO model)
        {
            //Verificar si ya existe la Patente desacoplando
            var patenteExist = await _vehiculoService.PatenteExist(model.Patente);
            if (patenteExist)
            {
                return BadRequest("La Patente ya existe el na Base de Datos");
            }

            //Verificar que el Color este escrito con la primera letra en Mayuscula

            bool v = _vehiculoService.ColorIsValid(model.Color);
            if (v) {
                return BadRequest("El Color debe comenzar con Mayuscula");
            }

            //Si no existe , insertar el registro evitando crear nuevos objetos, mejor hacerlo con Mapeo AutoMapper

            var entity = _mapper.Map<Vehiculo>(model);
            await _vehiculoService.Insert(entity);

            return Ok("Registro Guardado Correctamente");                                                  
        }

        [HttpPut]
        public ActionResult Put()
        {
            return Ok("HTTP PUT");
        }

        [HttpPatch]
        public ActionResult Patch()
        {
            return Ok("HTTP PATCH");
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok("HTTP DELTE");
        }
    }
}