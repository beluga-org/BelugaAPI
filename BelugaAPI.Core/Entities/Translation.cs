using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("translation")]
public class Translation
{
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public string id { get; set; }
    public string language { get; set; }
    [Column("video_id")]
    public string videoId { get; set; }
    //public Video video { get; set; }
    public string status { get; set; }
    [Column("translation_url")]
    public string? translationUrl { get; set; }
    [Column("subtitle_url")]
    public string? subtitleUrl { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    public DateTime? deleted { get; set; }
}