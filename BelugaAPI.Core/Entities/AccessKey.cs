using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("access_key")]
public class AccessKey
{
    [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
    public string id { get; set; }
    public string key { get; set; }
    [Column("user_id")]
    public string userId { get; set; }
    public User user { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    public DateTime? deleted { get; set; }
}