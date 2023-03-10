using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.Dtos;
using PetShopAPI.Models;
using PetShopAPI.Persistence;

namespace PetShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private PetShopContext _context;
        private IMapper _mapper;

        public AnimalController(PetShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateAnimalDto animalDto)
        {
            Animal animal = _mapper.Map<Animal>(animalDto);
            _context.Animais.Add(animal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOne), new {Id = animal.AnimalId}, animal);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Animais);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {

            Animal animal = _context.Animais.Where(animal => animal.AnimalId == id).Include(animal => animal.Plano).FirstOrDefault();

            if (animal != null)
            {
                ReadAnimalDto animalDto = _mapper.Map<ReadAnimalDto>(animal);
                animalDto.HoraDaConsulta = DateTime.Now;

                return Ok(animalDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateAnimalDto animalDto)
        {
            Animal animal = _context.Animais.Find(id);

            if(animal == null)
                return NotFound();

            _mapper.Map(animalDto, animal);

            _context.Animais.Update(animal);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Animal animal = _context.Animais.Find(id);

            if (animal == null)
                return NotFound();

            _context.Animais.Remove(animal);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
