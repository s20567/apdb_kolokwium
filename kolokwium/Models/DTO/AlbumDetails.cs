namespace kolokwium.Models.DTO
{
    public class AlbumDetails
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}