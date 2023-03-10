using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Dtos.PlanoDtos;
using PetShopAPI.Models;
using PetShopAPI.Persistence;

namespace PetShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        private PetShopContext _context;
        private IMapper _mapper;
        public PlanoController(PetShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePlanoDto planoDto)
        {
            Plano plano = _mapper.Map<Plano>(planoDto);

            _context.Planos.Add(plano);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOne), new {Id = plano.PlanoId }, plano);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Planos);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Plano plano = _context.Planos.Where(plano => plano.PlanoId == id).Include(plano => plano.Animais).FirstOrDefault();

            if (plano == null)
                return NotFound();

            ReadPlanoDto planoDto = _mapper.Map<ReadPlanoDto>(plano);

            return Ok(planoDto);
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdatePlanoDto planoDto, int id)
        {
            Plano plano = _context.Planos.Find(id);

            if (plano == null)
                return NotFound();

            _mapper.Map(planoDto, plano);

            _context.Planos.Update(plano);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Plano plano = _context.Planos.Find(id);

            if (plano == null)
                return NotFound();

            _context.Planos.Remove(plano);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
