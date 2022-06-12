using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Models;

public class Album
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAlbum { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string AlbumName { get; set; }
    
    [Required]
    public DateTime PublishDate { get; set; }
    
    public int IdMusicLabel { get; set; }
    
    [ForeignKey("IdMusicLabel")]
    public MusicLabel MusicLabel { get; set; }
}