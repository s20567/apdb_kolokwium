using kolokwium.Context;
using kolokwium.Models;
using kolokwium.Models.DTO;

namespace kolokwium.Services
{
    public class DbService : IDbService
    {
        private readonly AlbumDbContext _context;

        public DbService(AlbumDbContext context)
        {
            _context = context;
        }

        public async Task<AlbumDetails> GetAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMusician(int id)
        {
            throw new NotImplementedException();
        }
    }
}