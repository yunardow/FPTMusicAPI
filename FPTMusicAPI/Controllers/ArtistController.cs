using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPTMusicAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly DataContext _context;

        public ArtistController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Artist>>> Get()
        {
            return Ok(await _context.Artists.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Artist>>> Get(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return BadRequest("Artist not found");
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<List<Artist>>> AddArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return Ok(await _context.Artists.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Artist>>> UpdateArtist(Artist request)
        {
            var dbArtist = await _context.Artists.FindAsync(request.ArtistId);
            if (dbArtist == null) return BadRequest("Artist not found");

            dbArtist.ArtistName = request.ArtistName;
            dbArtist.AlbumName = request.AlbumName;
            dbArtist.ImageUrl = request.ImageUrl;
            dbArtist.ReleaseDate = request.ReleaseDate;
            dbArtist.Price = request.Price;
            dbArtist.SampleUrl = request.SampleUrl;

            await _context.SaveChangesAsync();
            return Ok(await _context.Artists.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Artist>>> Delete(int id)
        {
            var dbArtist = await _context.Artists.FindAsync(id);
            if (dbArtist == null) return BadRequest("Artist not found");

            _context.Artists.Remove(dbArtist);
            await _context.SaveChangesAsync();

            return Ok(await _context.Artists.ToListAsync());
        }
    }
}
