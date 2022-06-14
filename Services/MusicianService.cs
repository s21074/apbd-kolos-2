using kolos2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly RepositoryContext _repository;

        public MusicianService(RepositoryContext repository)
        {
            _repository = repository;
        }

        public IQueryable<Musician> GetMusicianById(int id)
        {
            return _repository.Musician
                .Include(e => e.Musician_Tracks)
                .Where(e => e.IdMusician == id);
                //.Include
        }

    }
}
