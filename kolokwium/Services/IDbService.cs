using kolokwium.Models.DTO;

namespace kolokwium.Services
{
    public interface IDbService
    {
        Task<AlbumDetails> GetAlbum(int id);
        Task DeleteMusician(int id);
    }
}