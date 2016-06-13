using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MusicHistoryLastOne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicHistoryLastOne.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class TracksController : Controller
    {
        private LastOneContext _context;
        private object StatusCodes;

        public TracksController(LastOneContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<FullTrack> track = from t in _context.Tracks
                                       join a in _context.Albums
                                       on t.AlbumId equals a.AlbumId 
                                       select new FullTrack{
                                           TrackTitle = t.TrackTitle,
                                           Artist = a.Artist,
                                           YearReleased = a.YearReleased,
                                           Genre = t.Genre,
                                           Author = t.Author,
                                           AlbumTitle = a.AlbumTitle,
                                           UserId = t.UserId,
                                           TrackId = t.TrackId
                                       };

            if (UserId != null)
            {
                track = track.Where(inv => inv.UserId == UserId);
            }

            if (track == null)
            {
                return NotFound();
            }
            return Ok(track);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTracks")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<TrackDetails> track = from t in _context.Tracks
                                             where t.TrackId == id
                                             join a in _context.Albums
                                             on t.AlbumId equals a.AlbumId
                                             select new TrackDetails
                                              {
                                                  TrackTitle = t.TrackTitle,
                                                  Author = t.Author,
                                                  Genre = t.Genre,
                                                  Artist = a.Artist,
                                                  YearReleased = a.YearReleased,
                                                  AlbumTitle = a.AlbumTitle
                                              };

            // Tracks track = _context.Tracks.Single(m => m.TrackId == id);

            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Tracks track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tracks.Add(track);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventoryExists(track.TrackId))
                {
                    return new StatusCodeResult(409);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTracks", new { id = track.TrackId }, track);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tracks track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.TrackId)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(204);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tracks track = _context.Tracks.Single(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            _context.SaveChanges();

            return Ok(track);
        }

        private bool InventoryExists(int id)
        {
            return _context.Tracks.Count(e => e.TrackId == id) > 0;
        }
    }
}
