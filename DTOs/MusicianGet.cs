
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolos2.DTOs
{
    public class MusicianGet
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }
}
