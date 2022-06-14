using kolos2.DTOs;
using kolos2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Controllers
{
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _service;

        public MusicianController(IMusicianService service)
        {
            _service = service;
        }

        [HttpGet("{musicianId")]
        public async Task<IActionResult> Get(int musicianId)
        {
            return Ok(
                await _service.GetMusicianById(musicianId)
                .Select(e =>
                new MusicianGet
                {
                    IdMusician = e.IdMusician,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Nickname = e.Nickname,
                    Tracks = e.Musician_Tracks.Select(e => new Track
                    { 
                        TrackId = e.IdTrack,
                        TrackName = e.Track.TrackName,
                        Duration = e.Track.Duration
                    }).ToList()
                }).ToListAsync()  
            );
        }

    }
}
