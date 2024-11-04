using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("video")]
public class Video
{
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string name { get; set; }
    [Column("original_language")]
    public string originalLanguage{ get; set; }
    [Column("user_id")]
    public int userId { get; set; }
    public User user { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
}