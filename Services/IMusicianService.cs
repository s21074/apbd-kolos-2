using kolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IMusicianService
    {
        public IQueryable<Musician> GetMusicianById(int id);
    }
}
