using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium.Models;

public class MusicianTrack
{
    [Key, Column(Order = 0)]
    public int IdTrack { get; set; }
    
    [Key, Column(Order = 1)]
    public int IdMusician { get; set; }
    
    [ForeignKey("IdTrack")]
    public Track Track { get; set; }
    
    [ForeignKey("IdMusician")]
    public Musician Musician { get; set; }
}