using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("translation")]
public class Translation
{
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string language { get; set; }
    [Column("video_id")]
    public int videoId { get; set; }
    public Video video { get; set; }
    public string content { get; set; }
    public string translationUrl { get; set; }
    public string transcriptionUrl { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    public DateTime deleted { get; set; }
}