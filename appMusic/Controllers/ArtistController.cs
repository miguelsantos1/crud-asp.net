using appMusic.Entities;
using appMusic.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly AppMusicDbContext _context;

        public ArtistController(AppMusicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var  artists = await _context.Artists.Include(a => a.Musics).ToListAsync();

            if (artists == null)
            {
                return NotFound();
            }

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var artist = _context.Artists.Include(a => a.Musics).SingleOrDefault(artist => artist.Id == id);

            if(artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpPost]
        public IActionResult Post(Artist artist)
        {
            _context.Artists.Add(artist);

            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var artist = _context.Artists.SingleOrDefault(artist => artist.Id == id);

            if (artist == null)
            {
                return NotFound();
            }
            _context.Artists.Remove(artist);
            _context.SaveChanges();

            return StatusCode(201);

        }

        [HttpPut("{id}/update")]
        public IActionResult Update(Guid id, Artist artist)
        {
            var artistSelected = _context.Artists.SingleOrDefault(artist => artist.Id == id);
            
            if (artistSelected == null)
            {
                return NotFound();
            }


            artistSelected.Update(artist.Name);

            _context.Artists.Update(artistSelected);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
