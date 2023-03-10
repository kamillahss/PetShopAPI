using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Dtos.ConsultaDtos;
using PetShopAPI.Models;
using PetShopAPI.Persistence;

namespace PetShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : ControllerBase
    {

        private PetShopContext _context;
        private IMapper _mapper;

        public ConsultaController(PetShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateConsultaDto consultaDto)
        {
            Consulta consulta = _mapper.Map<Consulta>(consultaDto);
            
            _context.Consultas.Add(consulta);
            _context.SaveChanges();

            return Created("localhost:5149/Consulta/" + consulta.VeterinarioId, consulta);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Consultas);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneByAnimalId(int id)
        {
            Consulta? consulta = _context.Consultas.Where(consulta => consulta.AnimalId == id).Include(consulta => consulta.Animal).Include(consulta => consulta.Veterinario).FirstOrDefault();
            
            if(consulta == null)
                return NotFound();

            ReadConsultaDto consultaDto = _mapper.Map<ReadConsultaDto>(consulta);

            return Ok(consultaDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteByAnimalId(int id)
        {
            Consulta consulta = _context.Consultas.Where(consulta => consulta.AnimalId == id).FirstOrDefault();

            if (consulta == null)
                return NotFound();

            _context.Consultas.Remove(consulta);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
