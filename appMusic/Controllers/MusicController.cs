using appMusic.Entities;
using appMusic.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly AppMusicDbContext _context;

        public MusicController(AppMusicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var musics = await _context.Musics.ToListAsync();

            return Ok(musics);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Post(Guid id, Music music)
        {

            var artist = await _context.Artists.SingleOrDefaultAsync(artist => artist.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            music.ArtistId = id;

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return Ok(music);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Music input)
        {
            var music = await _context.Musics.SingleOrDefaultAsync(music => music.Id == id);

            if(music == null)
            {
                return NotFound();
            }

            music.Update(input.Name, input.Genre);
            _context.SaveChanges();

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var music = await _context.Musics.FirstOrDefaultAsync(music => music.Id == id);

            if (music == null)
            {
                return NotFound();
            }

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
