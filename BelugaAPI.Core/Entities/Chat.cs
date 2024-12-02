using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelugaAPI.Core.Entities;

[Table("chat")]
public class Chat
{
    [Column("user_id")]
    public string userId { get; set; }
    [Column("video_id")]
    public string videoId { get; set; }
    public string threadId { get; set; }
    public DateTime created { get; set; }
    public DateTime updated { get; set; }
    
    public User user { get; set; }
    public Video video { get; set; }
}